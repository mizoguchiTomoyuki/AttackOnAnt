using UnityEngine;
using System.Collections;

public class TargetAttack : MonoBehaviour {
	public GameObject Target_Cake;
	public GameObject EscapePoint;
	private Animator _AntAnimator;
	public enum AntPROGRESS
	{
		WALK = 1,
		SURPRISE = 2,
		ESCAPE = 3,
		EAT = 4,
		DEATH = 5,
		DOWN = 6,
	};
	private BoxCollider2D boxel;
	private float surprise_count = 0;
	private AntPROGRESS progress = AntPROGRESS.WALK;
	private SpriteRenderer _AntSprite;
	private GameObject _Ant;
	public float speed=0.05f;
	public float walk_count = 0;
	public float attack_interval = 0.7f;
	public float _antScale=1.0f;
	private float attack_count = 0f;
	private float death_count = 0f;
	private float death_time = 4f;
	private float rand_x,rand_y,rand_z;
	private Color transparent = new Color(1,1,1,0.0f);
	// Use this for initialization
	void Start () {
		if (Target_Cake == null) {
			this.Destroy(this);
				}
		_AntAnimator = GetComponent<AntAnimation> ().AntAnimator;
		_Ant = GetComponent<AntAnimation> ().Ant;
		_AntSprite = _Ant.GetComponent<SpriteRenderer> ();
		boxel = GetComponent<BoxCollider2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		switch (progress) {
		case AntPROGRESS.WALK:
			walk_count+=Time.deltaTime;
			if(walk_count>1.1f){
				walk_count = 0;
				speed += 0.001f;
				if(speed >= 1){
					speed = 1;
				}
			}
			break;
		case AntPROGRESS.SURPRISE:
			surprise_count+= Time.deltaTime;
			speed =0f;
			if(surprise_count>0.5f){
				_AntAnimator.SetBool ("Escape",false);
				
				if (BGMManager.Instance)BGMManager.Instance.PlaySE (2);
				progress = AntPROGRESS.ESCAPE;
				Target_Cake = EscapePoint;
				speed =0.1f;
			}
			break;
		case AntPROGRESS.ESCAPE:

			break;
		case AntPROGRESS.EAT:
			_AntAnimator.SetBool ("Eat",true);
			attack_count += Time.deltaTime;
			if(attack_count<=0.5){
				_AntAnimator.SetBool ("Jump",true);
				speed=0.05f;
				Vector3 TagstVector =  Target_Cake.transform.position-this.transform.position;
				transform.Translate (TagstVector * speed);
			}else if(attack_count<=1.0){
				Vector3 TagreVector =  new Vector3(rand_x,rand_y,rand_z);
				Debug.Log (TagreVector);
				transform.Translate (TagreVector * speed*7);
			}else if(attack_count <= 1.0 +attack_interval){
				speed = 0;
				if (BGMManager.Instance)BGMManager.Instance.PlaySE (4);
			}else{
				AntGameManager.CakeEat(0.4f);
				attack_count = 0;
				speed=0.01f;
				progress = AntPROGRESS.WALK;
				_AntAnimator.SetBool ("Jump",false);

			}
			/*if(attack_count>attack_interval){
				if (BGMManager.Instance)BGMManager.Instance.PlaySE (4);
				attack_count=0;
				AntGameManager.CakeEat(0.1f);
			}*/
			break;
		case AntPROGRESS.DEATH:
			death_count+=Time.deltaTime;
			_AntSprite.color = Color.Lerp(Color.white,transparent,death_count/death_time);
			if(death_count>death_time){
			this.Destroy(this.gameObject);
			}
			speed = 0;
			break;
		case AntPROGRESS.DOWN:
			death_count+=Time.deltaTime;
			_AntSprite.color = Color.Lerp(Color.white,transparent,death_count/death_time);
			if(death_count>death_time){
				this.Destroy(this.gameObject);
			}
			speed = 0;
			break;
		}

		if (Vector3.Distance (this.transform.position, Target_Cake.transform.position) < 2 && progress == AntPROGRESS.WALK) {
			speed = 0;
			progress = AntPROGRESS.EAT;
			if (BGMManager.Instance)BGMManager.Instance.PlaySE (5);
			rand_x = Random.Range (-1f,1f);
			rand_y = Random.Range (-1,1f);
			rand_z = 0;

		}



		Vector3 TagVector =  Target_Cake.transform.position-this.transform.position;
		transform.Translate (TagVector * speed *_antScale *2);
	}
	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "impact") {
			Vector2 colPosition2D = new Vector2(col.transform.position.x,col.transform.position.y);
			Vector2 thisPosition2D = new Vector2(this.transform.position.x,this.transform.position.y);
			float dist = Vector2.Distance(colPosition2D,thisPosition2D);
			if(dist<0.3*_antScale){
				progress = AntPROGRESS.DEATH;
				_AntAnimator.SetBool ("Death",true);
				if (BGMManager.Instance)BGMManager.Instance.PlaySE (7);
				boxel.enabled = false;
				AntGameManager.DestroyAntAdd ();
			}else if(dist<0.6*_antScale){
				progress = AntPROGRESS.DOWN;
				_AntAnimator.SetBool ("Down",true);
				if (BGMManager.Instance)BGMManager.Instance.PlaySE (8);
				boxel.enabled = false;
				AntGameManager.DestroyAntAdd ();
			}else{
				progress = AntPROGRESS.SURPRISE;
				_AntAnimator.SetBool ("Escape",true);
				if (BGMManager.Instance)BGMManager.Instance.PlaySE (3);
			}
		}
	}
}

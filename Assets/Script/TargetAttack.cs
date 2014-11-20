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
	};
	private float surprise_count = 0;
	private AntPROGRESS progress = AntPROGRESS.WALK;
	public float speed=0.05f;
	public float walk_count = 0;
	public float attack_interval = 0.7f;
	private float attack_count = 0f;

	private float rand_x,rand_y,rand_z;
	// Use this for initialization
	void Start () {
		if (Target_Cake == null) {
			this.Destroy(this);
				}
		_AntAnimator = GetComponent<AntAnimation> ().AntAnimator;
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
		transform.Translate (TagVector * speed);
	}
	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "impact") {
			progress = AntPROGRESS.SURPRISE;
			_AntAnimator.SetBool ("Escape",true);
			if (BGMManager.Instance)BGMManager.Instance.PlaySE (3);
		}
	}
}

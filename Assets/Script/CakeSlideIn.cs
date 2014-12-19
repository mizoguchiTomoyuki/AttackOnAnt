using UnityEngine;
using System.Collections;

public class CakeSlideIn : MonoBehaviour {
	public GameObject pointA;
	public GameObject pointB;
	public GameObject Cake;
	public GameObject Smoke;
	public ProgressManager ProgManager;
	private float distance;
	private Vector3 _pointA, _pointB;
	public ZipAnimeSystem _zip;
	private float max_zipSlider=111f;
	private Vector3 LastPoint;
	private float time,counter,seccounter,rescounter;
	private bool reverseflag = false;
	private bool maxflag = false;
	private bool maxflag_res = false;
	private float rota = 30;
	// Use this for initialization
	void Start () {
		_pointA = pointA.transform.position;
		_pointB = pointB.transform.position;
		time = 3;
		counter = 0;
		seccounter = 0;
		maxflag = false;
		this.transform.position = _pointB;
		transform.eulerAngles = new Vector3(0,0,15);
		Cake.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (AntGameManager.progress == AntGameManager.PROGRESS.READYGAME) {
			if (!Cake.activeSelf) {
				if (!AntGameManager.reverse ) {
					Vector3 tmpPointA = _pointA;
					_pointA = _pointB;
					_pointB = tmpPointA;
					//this.transform.position = _pointA;
				}
								if (Smoke != null) {
										if (BGMManager.Instance)
												BGMManager.Instance.PlaySE (11);
												Instantiate (Smoke, this.transform.position, Quaternion.identity);
								}
								Cake.SetActive (true);

						}
						//	Debug.Log (_zip.IL);
						float maxtime = time * (float)_zip.IL / max_zipSlider;
						counter = AntGameManager.progcounter;
						time = (float)AntGameManager.progressCounter[(int)AntGameManager.progress];
					if ( counter > time) {
						counter = time;
								if (!maxflag) {
										if (BGMManager.Instance)BGMManager.Instance.PlaySE (9);
										transform.position = _pointB + LastPoint * (counter / time);
										transform.eulerAngles = new Vector3 (0, 0, 0);
										maxflag = true;
										BGMManager.Instance.PlayBGM(0, 1);
										AntGameManager.ProgressStepUP();
								}
						}
						LastPoint = new Vector3 ((_pointA.x - _pointB.x) * ((float)_zip.IL / max_zipSlider), 0, 0);
						//	LastPoint = (_pointA + _pointB) - _pointB * (_zip.IL / max_zipSlider);
						Debug.Log (LastPoint);
						seccounter += Time.deltaTime;
						if (seccounter > 0.3f) {
								if (BGMManager.Instance)
										BGMManager.Instance.PlaySE (10);
								seccounter = 0;
								transform.position = _pointB + LastPoint * (counter / time);
								transform.Rotate (new Vector3 (0, 0, -rota));
								rota = -rota;
								Debug.Log (rota);
						}
		
				}
			if (AntGameManager.progress == AntGameManager.PROGRESS.RESULTGAME) {
				//	Debug.Log (_zip.IL);
				if(rescounter> 1f){
				if(!maxflag_res){
						//if (BGMManager.Instance)BGMManager.Instance.PlaySE (9);
					transform.eulerAngles = new Vector3(0,0,0);
					transform.position =   (_pointB*2 + LastPoint)/2f;
					maxflag_res = true;
					AntGameManager.CAKESTATE state = AntGameManager.cake_state;
					switch (state) {
					case AntGameManager.CAKESTATE.NORMAL:
						if (BGMManager.Instance)BGMManager.Instance.PlaySE (12);
						break;
					case AntGameManager.CAKESTATE.DAMAGE_1:
						if (BGMManager.Instance)BGMManager.Instance.PlaySE (13);
						break;
					case AntGameManager.CAKESTATE.DAMAGE_2:
						if (BGMManager.Instance)BGMManager.Instance.PlaySE (14);
						break;
					case AntGameManager.CAKESTATE.DAMAGE_3:
						if (BGMManager.Instance)BGMManager.Instance.PlaySE (15);
						break;
					case AntGameManager.CAKESTATE.DAMAGE_4:
						if (BGMManager.Instance)BGMManager.Instance.PlaySE (16);
						break;
						
					}
				}
				}else{
				if(rescounter == 0){
					transform.eulerAngles = new Vector3(0,0,15);
					rota = 30;
						}
					rescounter += Time.deltaTime;
				//	LastPoint = (_pointA + _pointB) - _pointB * (_zip.IL / max_zipSlider);
				Debug.Log (LastPoint);
				seccounter+=Time.deltaTime;
				if(seccounter>0.2f){
					if (BGMManager.Instance)BGMManager.Instance.PlaySE (10);
					seccounter = 0;
					Debug.Log (rescounter/2f);
					Vector3 resPoint = new Vector3((_pointB.x + LastPoint.x ) - ((LastPoint.x)/2f)*(rescounter/1f),_pointB.y,_pointB.y);
					transform.localPosition =   resPoint;
					transform.Rotate(new Vector3(0,0,-rota));
					rota = -rota;
					Debug.Log (rota);
				}
			}
				


		}
		if (AntGameManager.progress == AntGameManager.PROGRESS.STARTWAIT) {
			Cake.SetActive (false);
			if(!AntGameManager.reverse){
				this.transform.position = _pointA;
			}else{
				this.transform.position = _pointB;

			}
			rota = 30;
			transform.eulerAngles = new Vector3(0,0,15);
			reverseflag = false;
			counter = 0;
			rescounter = 0;
			maxflag = false;
			maxflag_res = false;
		}
	}
}


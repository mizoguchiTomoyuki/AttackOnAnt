using UnityEngine;
using System.Collections;

public class CakeSlideIn : MonoBehaviour {
	public GameObject pointA;
	public GameObject pointB;
	private float distance;
	private Vector3 _pointA, _pointB;
	public ZipAnimeSystem _zip;
	private float max_zipSlider=171f;
	private Vector3 LastPoint;
	private float time,counter;
	private bool reverseflag = false;
	private bool maxflag = false;
	// Use this for initialization
	void Start () {
		_pointA = pointA.transform.position;
		_pointB = pointB.transform.position;
		time = 3;
		counter = 0;
		this.transform.position = _pointB;
	}
	
	// Update is called once per frame
	void Update () {
		if (AntGameManager.progress == AntGameManager.PROGRESS.READYGAME) {
			if(!AntGameManager.reverse && !reverseflag){
				reverseflag = true;
				Vector3 tmpPointA = _pointA;
				_pointA = _pointB;
				_pointB = tmpPointA;
				this.transform.position = _pointB;
			}
			Debug.Log (_zip.IL);
			float maxtime = time*(float)_zip.IL / max_zipSlider;
			counter += Time.deltaTime;
			if(counter> maxtime){
				if(!maxflag){
					if (BGMManager.Instance)BGMManager.Instance.PlaySE (9);
					maxflag = true;
				}
				counter = maxtime;
			}
			LastPoint = new Vector3((_pointA.x-_pointB.x)*((float)_zip.IL / max_zipSlider),0,0);
					//	LastPoint = (_pointA + _pointB) - _pointB * (_zip.IL / max_zipSlider);
						Debug.Log (LastPoint);
			transform.position =  _pointB + LastPoint *(counter/maxtime);
				}
		
		if (AntGameManager.progress == AntGameManager.PROGRESS.STARTWAIT) {
			reverseflag = false;
			counter = 0;
			this.transform.position = _pointB;
			maxflag = false;
		}
	}
}

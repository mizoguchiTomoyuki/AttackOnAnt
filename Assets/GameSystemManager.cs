using UnityEngine;
using System.Collections;

public class GameSystemManager : MonoBehaviour {
	public float time;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(AntGameManager.stflag){
		AntGameManager.time -= Time.deltaTime;
		if (AntGameManager.time < 0) {
			AntGameManager.time = 0;
		//	AntGameManager.time--;
		}
		}
	}
}

using UnityEngine;
using System.Collections;

public class GameSystemManager : MonoBehaviour {
	public float time;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(AntGameManager.progress == AntGameManager.PROGRESS.PLAYGAME){
		AntGameManager.time -= Time.deltaTime;
		if (AntGameManager.time < 0) {
			AntGameManager.time = 0;
		//	AntGameManager.time--;
		}
		}
	}
	public void SetTimer(float n){
				if (AntGameManager.progress == AntGameManager.PROGRESS.STARTWAIT) {
						AntGameManager.SetTime (n);
				}
		}
	public void ReverseStage(){
		AntGameManager.TurnReverse ();
	}
	public void ChangeSnipe(){
		AntGameManager.TurnSnipe ();
	}
}

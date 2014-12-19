using UnityEngine;
using System.Collections;

public class ProgressManager : MonoBehaviour {
	public float progressCount = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		AntGameManager.PROGRESS prog = AntGameManager.progress;
		if (prog == AntGameManager.PROGRESS.READYGAME || prog == AntGameManager.PROGRESS.RESULTGAME) {
			progressCount += Time.deltaTime;
			AntGameManager.progcounter = progressCount;
			//Debug.Log(prog + "time :" + progressCount);
			if(prog == AntGameManager.PROGRESS.RESULTGAME){
			if(progressCount > AntGameManager.progressCounter[(int)prog]){
				progressCount = 0;
				AntGameManager.ProgressStepUP();
			
			}
			}
		}
		
		if(AntGameManager.progress == AntGameManager.PROGRESS.PLAYGAME){
			float temp_timer = AntGameManager.GetTime();
			if (temp_timer <= 0) {
			AntGameManager.ProgressStepUP();
			}
		}
	}
}

using UnityEngine;
using System.Collections;

public class ProgressManager : MonoBehaviour {
	float progressCount = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		AntGameManager.PROGRESS prog = AntGameManager.progress;
		if (prog  == AntGameManager.PROGRESS.READYGAME || prog == AntGameManager.PROGRESS.RESULTGAME) {
			progressCount += Time.deltaTime;
			//Debug.Log(prog + "time :" + progressCount);
			if(progressCount > AntGameManager.progressCounter[(int)prog]){
				if(prog == AntGameManager.PROGRESS.READYGAME){
					
					BGMManager.Instance.PlayBGM(0, 1);
				}
				progressCount = 0;
				AntGameManager.ProgressStepUP();
			
			}
		}
	}
}

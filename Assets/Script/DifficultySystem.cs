using UnityEngine;
using System.Collections;

public class DifficultySystem : MonoBehaviour {

	public int difficult_checker;
	//public GameObject aObject;
	public GameObject bObject;
	public ZipAnimeSystem aScript;
	public AntCreator bScript;
	// Use this for initialization
	void Start () {
			aScript = GetComponent<ZipAnimeSystem>();
			difficult_checker = aScript.IL;
		
		if(bObject!=null){
		bScript = bObject.GetComponent<AntCreator>();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (AntGameManager.progress == AntGameManager.PROGRESS.READYGAME) {
						difficult_checker = aScript.IL;
						//Debug.Log("test");
						if (difficult_checker >= 110) {
								difficult_checker = 110;
						}
						AntGameManager.SetDifficult((float)difficult_checker/110f);
						float _difficult = AntGameManager.difficult;
						bScript.max_Ant = (int)(50*_difficult);
						bScript.interval = (1.3f - _difficult);
						bScript.Max_Range = 25 + (int)(16*_difficult);
						bScript.Min_Range = 16 - (int)(16*_difficult);
						bScript.AntScale = (1.5f - _difficult);
				}
		/*if(difficult_checker>=110){
			bScript.max_Ant = 40;
			bScript.Max_Range = 41;
			bScript.Min_Range = 0;
		}
		else if(difficult_checker>=60){
		}
		else if(difficult_checker>=10){
			bScript.max_Ant = 10;
			bScript.Max_Range = 25;
			bScript.Min_Range = 16;
		}*/
	}
}

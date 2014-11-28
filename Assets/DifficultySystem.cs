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
		difficult_checker = aScript.IL;
		//Debug.Log("test");
		if(difficult_checker>=110){
			difficult_checker=110;
		}
		bScript.max_Ant=difficult_checker*40/110;
		bScript.Max_Range=25+difficult_checker*34/110;
		bScript.Min_Range=16-difficult_checker*16/110;
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

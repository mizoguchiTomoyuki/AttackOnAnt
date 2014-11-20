using UnityEngine;
using System.Collections;

public class AppearAndSE : MonoBehaviour {
	[Range(0,1)]
	public int SE_Number;
	public bool DelayFlag = false;
	public float Delay = 0.0f;
	private float counttime = 0.0f;
	// Use this for initialization
	void Start () {
		if (!DelayFlag) {
						if (BGMManager.Instance)BGMManager.Instance.PlaySE (SE_Number);
				}
	
	}
	
	// Update is called once per frame
	void Update () {
		if (DelayFlag) {
			counttime += Time.deltaTime;
			if(counttime>Delay){
			if (BGMManager.Instance)BGMManager.Instance.PlaySE (SE_Number);
				DelayFlag  =false;
			}
		}
	
	}
}

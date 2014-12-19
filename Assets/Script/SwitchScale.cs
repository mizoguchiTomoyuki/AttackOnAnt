using UnityEngine;
using System.Collections;

public class SwitchScale : MonoBehaviour {
	
	private bool switchflag = false;
	private Vector3 OriginScale;
	private Vector3 ReverseScale;
	// Use this for initialization
	void Start () {
		
		OriginScale = this.transform.localScale;
		ReverseScale = new Vector3 (-OriginScale.x, OriginScale.y, OriginScale.z);
	}
	
	// Update is called once per frame
	void Update () {
		if (!AntGameManager.reverse) {
			this.transform.localScale = ReverseScale;
		} else {
			this.transform.localScale = OriginScale;
			
		}
	}
}

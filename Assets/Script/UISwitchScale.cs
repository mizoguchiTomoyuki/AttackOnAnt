using UnityEngine;
using System.Collections;

public class UISwitchScale : MonoBehaviour {
	private RectTransform _rect;
	private bool switchflag = false;
	private Vector3 OriginScale;
	private Vector3 ReverseScale;
	// Use this for initialization
	void Start () {
		_rect = GetComponent<RectTransform> ();
		OriginScale = this.transform.localScale;
		ReverseScale = new Vector3 (-OriginScale.x, OriginScale.y, OriginScale.z);
	}
	
	// Update is called once per frame
	void Update () {
			if (!AntGameManager.reverse) {
						_rect.localScale = ReverseScale;
		} else {
			_rect.localScale = OriginScale;

				}
	}
}

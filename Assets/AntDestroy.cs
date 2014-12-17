using UnityEngine;
using System.Collections;

public class AntDestroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	if (AntGameManager.progress == AntGameManager.PROGRESS.RESULTGAME) {
			this.Destroy(this.gameObject);
				}
	}
}

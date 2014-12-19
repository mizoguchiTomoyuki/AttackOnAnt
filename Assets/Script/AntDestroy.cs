using UnityEngine;
using System.Collections;

public class AntDestroy : MonoBehaviour {
	public GameObject smoke;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	if (AntGameManager.progress == AntGameManager.PROGRESS.RESULTGAME) {
			if(smoke != null){Instantiate(smoke,this.transform.position,Quaternion.identity);}
			this.Destroy(this.gameObject);
				}
	}
}

using UnityEngine;
using System.Collections;

public class EnemyDeleter : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		AntGameManager.DestroyAntAdd ();
		Destroy (other.gameObject);
	}
}

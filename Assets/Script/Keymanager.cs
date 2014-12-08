using UnityEngine;
using System.Collections;

public class Keymanager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey("escape")){
			AntGameManager.QuitGame();
		}
	}
}

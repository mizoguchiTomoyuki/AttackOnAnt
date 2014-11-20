using UnityEngine;
using System.Collections;

public class GameSystemManager : MonoBehaviour {
	public float time;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if (time > 1) {
			time = 0;
			AntGameManager.time--;
		}
	
	}
}

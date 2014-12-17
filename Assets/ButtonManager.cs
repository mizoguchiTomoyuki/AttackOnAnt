using UnityEngine;
using System.Collections;

public class ButtonManager : MonoBehaviour {
	public GameObject[] Buttons;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		AntGameManager.PROGRESS prog = AntGameManager.progress;
		if (prog == AntGameManager.PROGRESS.STARTWAIT) {
						for (int i= 0; i<Buttons.Length; i++) {
								Buttons [i].SetActive (true);
						}
		}else{
			for (int i= 0; i<Buttons.Length; i++) {
				Buttons [i].SetActive (false);
			}
		}
	}
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeText : MonoBehaviour {

	Text Time_Text;
	// Use this for initialization
	void Start () {
		Time_Text = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		Time_Text.text = AntGameManager.time.ToString();
	}
}

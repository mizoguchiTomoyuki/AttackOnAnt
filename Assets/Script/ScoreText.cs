using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour {
	Text Score_Text;
	// Use this for initialization
	void Start () {
		Score_Text = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		Score_Text.text = AntGameManager.destroy_AntNum.ToString();
	}
}

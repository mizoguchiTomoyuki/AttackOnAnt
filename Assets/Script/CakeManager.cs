using UnityEngine;
using System.Collections;

public class CakeManager : MonoBehaviour {
	private SpriteRenderer CakeSpriteRen;
	private bool damageflag = false;
	// Use this for initialization
	void Start () {
		CakeSpriteRen = GetComponent<SpriteRenderer> ();
		CakeSpriteRen.sprite = AntGameManager.GetSprite("cake_","cake__0");
	}
	
	// Update is called once per frame
	void Update () {
		AntGameManager.CAKESTATE state = AntGameManager.cake_state;
		switch (state) {
		case AntGameManager.CAKESTATE.NORMAL:
			break;
		case AntGameManager.CAKESTATE.DAMAGE_1:
			CakeSpriteRen.sprite = AntGameManager.GetSprite("cake_","cake__1");
			break;
		case AntGameManager.CAKESTATE.DAMAGE_2:
			CakeSpriteRen.sprite = AntGameManager.GetSprite("cake_","cake__2");
			break;
		case AntGameManager.CAKESTATE.DAMAGE_3:
			CakeSpriteRen.sprite = AntGameManager.GetSprite("cake_","cake__3");
			break;
		case AntGameManager.CAKESTATE.DAMAGE_4:
			CakeSpriteRen.sprite = AntGameManager.GetSprite("cake_","cake__4");
			break;

				}
	
	}
}

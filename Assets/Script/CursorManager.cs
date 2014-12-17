using UnityEngine;
using System.Collections;

public class CursorManager : MonoBehaviour {
	public Texture2D cursorTexture;
	Vector2 hotSpot;
	
	void Awake ()
	{
		//Screen.showCursor = false;
		//Cursor.SetCursor(cursorTexture, hotSpot, CursorMode.Auto);

	}
	/*
	void OnMouseEnter () 
	{
		Cursor.SetCursor(cursorTexture, hotSpot, CursorMode.Auto);
	}
	
	void OnMouseExit ()
	{
		Cursor.SetCursor (null, Vector2.zero, CursorMode.Auto);
	}

*/
}

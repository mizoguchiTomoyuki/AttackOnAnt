using UnityEngine;
using System.Collections;

public class HandManager : MonoBehaviour {

	public GameObject hand;
	public RectTransform _hand_transform;
	public Animator _hand_animator;
	public ZipAnimeSystem zaScript;
	//public Camera _camera;
	void Awake ()
	{
		Screen.showCursor = false;
	}
	// Use this for initialization
	void Start () {
		zaScript = GetComponent<ZipAnimeSystem>();
		_hand_transform = hand.GetComponent<RectTransform>();
		_hand_animator = hand.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		_hand_animator.SetBool("grip",false);
		/*		Screen.showCursor = false;
		Vector3 vec = Input.mousePosition;
		vec.z = 0f;
		
		_hand_transform.position = vec;*/
		Vector3 vec = Input.mousePosition;
		vec.z = 0f;
		
		_hand_transform.position = vec;
		if(zaScript.progress == ZipAnimeSystem.PROGRESS.OPENZIPPER){
			_hand_animator.SetBool("zipper",true);
		if (Input.GetMouseButtonDown(0)){
			//_hand_transform.RotateAround(Vector3.up, 2f);
			_hand_animator.SetBool("bang", true);
		}
		if (Input.GetMouseButtonUp(0)) {
			_hand_animator.SetBool("bang", false);
		}
		}
	}
}

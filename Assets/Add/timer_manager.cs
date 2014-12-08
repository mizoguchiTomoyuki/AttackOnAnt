using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class timer_manager : MonoBehaviour {

	// Use this for initialization
	private float startTime = 61.0f; // seconds
	public float timer;
	public GameObject slider;
	public Slider _slider;
	public GameObject _time_text;
	public GameObject _second_text;
	public GameObject _handle;
	public Text _text;
	public Text _second;
	public RectTransform _text_transform;
	public RectTransform _second_transform;
	public RectTransform _handle_transform;
	private float Original_y = -1.574461f;
	private float Original_y_sec = -3.210923f;
	private float x_position=0;
	private float x_max = 72.688f;
	private float x_min = -47.163f;
	private float x_length = 0;

	void Start()
	{
		x_length = x_max-x_min;
		reset();
	//	slider = GameObject.Find("Slider");
		_slider = slider.GetComponent<Slider>();
		_text = _time_text.GetComponent<Text>();
		_text_transform = _time_text.GetComponent<RectTransform>();
		//_second = _second_text.GetComponent<Text>();
		//_second_transform = _second_text.GetComponent<RectTransform>();
		//Original_y= _text_transform.localPosition.y;
		//x_max= _text_transform.localPosition.x;
		_handle_transform = _handle.GetComponent<RectTransform>();
	}
	
	void reset()
	{
		//timer = startTime;
	}
	
	void Update()
	{
		if(AntGameManager.stflag){
		timer =  AntGameManager.time;
		int temp_timer = AntGameManager.GetTime();
		_slider.value = timer;
		_text.text = temp_timer.ToString();
		if (temp_timer <= 0)
		{
			temp_timer = 0;
			
			// 何かの処理. 
			//AntGameManager.stflag = false;
			
			
		}
		_handle_transform.localPosition=new Vector3(x_min + x_length*timer/startTime,Original_y,0);
		_text_transform.localPosition=new Vector3(x_min + x_length*timer/startTime,Original_y,0);
		//_second_transform.localPosition=new Vector3(x_min + x_length*timer/startTime +5,Original_y_sec,0);
		}
	}

}

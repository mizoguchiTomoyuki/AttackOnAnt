using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class timer_manager : MonoBehaviour {

	// Use this for initialization
	public float startTime = 60.0f; // seconds
	public float timer;
	public GameObject slider;
	public Slider _slider;
	public GameObject _time_text;
	public GameObject _second_text;
	public Text _text;
	public Text _second;
	public RectTransform _text_transform;
	public RectTransform _second_transform;
	public float Original_y = -2.206374f;
	public float Original_y_sec = -3.210923f;
	private float x_position=0;
	public float x_max = 73.372f;
	public float x_min = -37.822f;
	public float x_length = 0;

	void Start()
	{
		x_length = x_max-x_min;
		reset();
		slider = GameObject.Find("Slider");
		_slider = slider.GetComponent<Slider>();
		_text = _time_text.GetComponent<Text>();
		_text_transform = _time_text.GetComponent<RectTransform>();
		_second = _second_text.GetComponent<Text>();
		_second_transform = _second_text.GetComponent<RectTransform>();
	}
	
	void reset()
	{
		//timer = startTime;
	}
	
	void Update()
	{
		timer =  AntGameManager.time;
		int temp_timer = AntGameManager.GetTime();
		_slider.value = timer;
		_text.text = temp_timer.ToString();
		_text_transform.localPosition=new Vector3(x_min + x_length*timer/startTime,Original_y,0);
		_second_transform.localPosition=new Vector3(x_min + x_length*timer/startTime +5,Original_y_sec,0);
		if (timer <= 0.0f)
		{
			timer = 0.0f;

			// 何かの処理


		}
	}

}

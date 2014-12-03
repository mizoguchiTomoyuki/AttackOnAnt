﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ZipAnimeSystem : MonoBehaviour {
	
	private Sprite[] sprites;
	//public Texture[] textures;
	public GameObject _starter;
	public SpriteRenderer spriteRenderer;
	public float interval;
	public GameObject zipper_slider;
	public GameObject time_slider;
	public Slider _zipper_slider;
	public Slider _time_slider;
	public GameObject _motite;
	public RectTransform _motite_transform;
	//Add 
	public bool zipflag = false;
	public bool autoflag = false;
	public AudioSource aud;
	public float premouseposition_x = 0;
	public float zipaudioCounter = 0;
	public float prepitch_upper = 0;
	//public Image _motite_img;
	public int I=0;
	public int IL;
	public GameObject hand;
	public Animator _hand_animator;
	public float zipper_counter=0;
	public enum PROGRESS{
		NORMAL = 0,
		BUTTONDOWN = 1,
		BUTTONUP = 2,
		OPENZIPPER = 3,
		ENDZIPPER = 4,
	};
	public PROGRESS progress;
	//public float time_counter;
	//const string base_texture = "Resorces/zipper/zipper_00000"

		// Use this for initialization
	void Awake () {
		progress = PROGRESS.NORMAL;
		spriteRenderer = _starter.GetComponent<SpriteRenderer>();
		sprites = Resources.LoadAll<Sprite>("zipper");
		//textures = Resources.LoadAll<Texture>("zipper");
		if(zipper_slider!=null){
			_zipper_slider = zipper_slider.GetComponent<Slider>();
			I=111-(int)_zipper_slider.value;
		}
		if(time_slider!=null){
			_time_slider = time_slider.GetComponent<Slider>();
		time_slider.SetActive(false);
		}
		if(hand!=null){
			_hand_animator = hand.GetComponent<Animator>();
		}
		if(_motite!=null){
			//_motite_img = _motite.GetComponent<Image>();
			_motite_transform = _motite.GetComponent<RectTransform>();
		}
	}
	//IEnumerator Start (){
	void Update(){
		if (zipflag) {
			zipaudioCounter+= Time.deltaTime;
			if(zipaudioCounter > 0.001){
			if(!autoflag){
					zipaudioCounter = 0;

				float pitch_upper = Mathf.Pow (Mathf.Abs((premouseposition_x - Input.mousePosition.x)/500),1f);
					if(premouseposition_x - Input.mousePosition.x<0){
						pitch_upper = Mathf.Pow (Mathf.Abs((premouseposition_x - Input.mousePosition.x)/1000),1f);

					}
					if(premouseposition_x - Input.mousePosition.x==0){
						pitch_upper = 0;
						
					}
					Debug.Log (pitch_upper);
					if(premouseposition_x - Input.mousePosition.x <= prepitch_upper){
						
						Debug.Log ("Back");
						aud.pitch -= pitch_upper+0.01f;
					}else if(premouseposition_x - Input.mousePosition.x > prepitch_upper){
						aud.pitch += pitch_upper+0.03f;
						Debug.Log ("Gain");

					}
					if(premouseposition_x - Input.mousePosition.x == 0){
						Debug.Log ("Equal");
						aud.pitch -= 0.1f;
					}
					//aud.pitch = pitch_upper;
					prepitch_upper = premouseposition_x - Input.mousePosition.x;
					if(aud.pitch >0.8f){
						aud.pitch =0.8f;
					}
					if(aud.pitch < 0.0f){
						aud.pitch =0.0f;
					}
			aud.Play();
			premouseposition_x = Input.mousePosition.x;
			}else{
					float pitch_upper = Mathf.Sin (((I-IL)/(float)(171-IL))*Mathf.PI);
					//Debug.Log (pitch_upper);
					if(pitch_upper > 1f){
						pitch_upper =1f;
				}
				aud.pitch = pitch_upper;
				aud.Play();

			}
			}
				}
		//_hand_animator.SetBool("zipper",false);
		int slider_value= (int) _zipper_slider.value;
		//int i=0;
		//while(true){
			//yield return new WaitForSeconds(interval);
			//i=i+1;
			//I=i*2;
		//if(slider_value==0){
		//	IL=I;
		//}
		//if(slider_value>0 && Input.GetMouseButtonUp(0)){
		if(progress != PROGRESS.ENDZIPPER){
			if(progress != PROGRESS.OPENZIPPER){
				/*if(Input.GetMouseButton(0)){
					_hand_animator.SetBool("grip",true);
					_hand_animator.SetBool("zipper",false);
				}*/
		if(Input.GetMouseButtonDown(0)){
					zipflag = true;
					_hand_animator.SetBool("grip",true);
					_hand_animator.SetBool("zipper",false);
					progress = PROGRESS.BUTTONDOWN;
			zipper_counter =0;
		}
		if(Input.GetMouseButtonUp(0) && progress==PROGRESS.BUTTONDOWN && I!=0){
			IL=I;
			progress = PROGRESS.BUTTONUP;
			zipflag = false;
		}
		if(progress==PROGRESS.BUTTONUP){
			zipper_counter+=Time.deltaTime;
					if(zipper_counter>=1){
						zipflag = true;
						autoflag = true;
				progress = PROGRESS.OPENZIPPER;
						AntGameManager.ProgressStepUP();
			}
		}
			}
		if(slider_value<=0 || progress == PROGRESS.OPENZIPPER){
			//I=IL;
				
				int a = 1+(int)(((I-IL)/(float)(171-IL))*10);
				I+=a;
				//_motite_transform.localPosition -= Vector3.right*(I*6);
				//_motite_img.color = new Color(0,0,0,0);
				_motite.SetActive(false);
		}else{
			I=111-slider_value;
		}
		if(I>171){
				I=171;
				aud.pitch = 0;
				zipflag = false;
				autoflag = false;
				AntGameManager.stflag =true;
			zipper_slider.SetActive(false);
			time_slider.SetActive(true);
			_starter.SetActive(false);
				//_hand_animator.SetBool("zipper",true);
				//progress = PROGRESS.ENDZIPPER;
			//break;
			}
		if(I>=0 && I<sprites.Length){
			spriteRenderer.sprite = sprites[I];
			//I++;
		}
		//}
		}
	}
}

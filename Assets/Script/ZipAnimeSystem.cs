using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ZipAnimeSystem : MonoBehaviour {
	
	private Sprite[] sprites;
	//public Texture[] textures;
	public GameObject _starter;
	public SpriteRenderer spriteRenderer;
	public float interval;

	public GameObject zipper_slider;
	public Slider _zipper_slider;
	private int max_zipSlider=111;
	private int max_zipAnimValue=171;

	public GameObject time_slider;
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

	public float endtimeCounter = 0;
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

		if(zipper_slider!=null){
			_zipper_slider = zipper_slider.GetComponent<Slider>();
			I=111-(int)_zipper_slider.value;
		}
		if(hand!=null){
			_hand_animator = hand.GetComponent<Animator>();
		}
		if(_motite!=null){

			_motite_transform = _motite.GetComponent<RectTransform>();
		}
	}
	//IEnumerator Start (){
	void Update(){
		if (zipflag && I!=0) {
			zipaudioCounter+= Time.deltaTime;
			if(zipaudioCounter > 0.001){
			if(!autoflag){
					zipaudioCounter = 0;
					Vector3 mousePos = Input.mousePosition;
					if(AntGameManager.reverse){
						mousePos = new Vector3(-mousePos.x,mousePos.y,mousePos.z);
					}
				float pitch_upper = Mathf.Pow (Mathf.Abs((premouseposition_x - mousePos.x)/500),1f);
					if(premouseposition_x - mousePos.x<0){
						pitch_upper = Mathf.Pow (Mathf.Abs((premouseposition_x - mousePos.x)/1000),1f);

					}
					if(premouseposition_x - mousePos.x==0){
						pitch_upper = 0;
						
					}
					//Debug.Log (pitch_upper);
					if(premouseposition_x - mousePos.x <= prepitch_upper){
						
					//	Debug.Log ("Back");
						aud.pitch -= pitch_upper+0.01f;
					}else if(premouseposition_x - mousePos.x > prepitch_upper){
						aud.pitch += pitch_upper+0.03f;
					//	Debug.Log ("Gain");

					}
					if(premouseposition_x - mousePos.x == 0){
					//	Debug.Log ("Equal");
						aud.pitch -= 0.1f;
					}

					prepitch_upper = premouseposition_x - mousePos.x;
					if(aud.pitch >0.8f){
						aud.pitch =0.8f;
					}
					if(aud.pitch < 0.0f){
						aud.pitch =0.0f;
					}
			aud.Play();
			premouseposition_x = mousePos.x;
			}else{
				
					float pitch_upper = 0;;
					if(AntGameManager.progress == AntGameManager.PROGRESS.ENDGAME){
						pitch_upper = -Mathf.Sin (((I-171)/(float)(171))*Mathf.PI);
					}else{
						pitch_upper = Mathf.Sin (((I-IL)/(float)(max_zipSlider-IL))*Mathf.PI);
					}
					if(pitch_upper > 1f){
						pitch_upper =1f;
				}
				aud.pitch = pitch_upper;
				aud.Play();

			}
			}
				}

		int slider_value= (int) _zipper_slider.value;

		if(progress != PROGRESS.ENDZIPPER){
			if(progress != PROGRESS.OPENZIPPER){

		if(Input.GetMouseButtonDown(0)){
					zipflag = true;
				//	_hand_animator.SetBool("grip",true);
				//	_hand_animator.SetBool("zipper",false);
					progress = PROGRESS.BUTTONDOWN;
					zipper_counter =0;
		}
		if(Input.GetMouseButtonUp(0) && progress==PROGRESS.BUTTONDOWN && I!=0){
			IL=I; //IL(ILast)はIの最終的な値である. 
			progress = PROGRESS.BUTTONUP;
			zipflag = false;
		}
		if(progress==PROGRESS.BUTTONUP){
			zipper_counter+=Time.deltaTime;
					if(zipper_counter>=1){
						zipflag = true;
						autoflag = true;
						progress = PROGRESS.OPENZIPPER;
					}
		}
			}
		if(slider_value<=0 || progress == PROGRESS.OPENZIPPER){
			//I=IL;
				if(progress != PROGRESS.OPENZIPPER){
					IL = max_zipSlider;
					progress = PROGRESS.OPENZIPPER;
				}
				if(AntGameManager.progress == AntGameManager.PROGRESS.STARTWAIT){
					
					AntGameManager.ProgressStepUP();
				}
				int a = 1+(int)(((I-IL)/(float)(max_zipSlider-IL))*10);
				I+=a;

				_motite.SetActive(false);
		}else{
				I=max_zipSlider-slider_value; //Iの値はZipperのスライダーの最大値から現在のスライダーの値を引いたものである. 
		}
			if(I>max_zipAnimValue){ //Iの値がアニメの最終番号に到達したら. 
				I=max_zipAnimValue;
				aud.pitch = 0;
				zipflag = false;
				autoflag = false;
				progress = PROGRESS.ENDZIPPER;
				if(!AntGameManager.stflag){
					if(BGMManager.Instance)
					{
						BGMManager.Instance.PlaySE(6);

					}
				}
				AntGameManager.stflag =true;
			zipper_slider.SetActive(false);
			time_slider.SetActive(true);
			_starter.SetActive(false);


			}
		if(I>=0 && I<sprites.Length){
			spriteRenderer.sprite = sprites[I];

		}

		}
		float temp_timer = AntGameManager.GetTime();
		Debug.Log (AntGameManager.progress);
		if (temp_timer <= 0) {
			if(AntGameManager.progress == AntGameManager.PROGRESS.ENDGAME){
				time_slider.SetActive(false);
				autoflag = true;
				zipflag = true;
				zipper_slider.SetActive(true);
				_starter.SetActive(true);
				if(BGMManager.Instance)
				{
					BGMManager.Instance.StopBGM();
				}
			endtimeCounter+=Time.deltaTime;

			if(endtimeCounter>4){
				endtimeCounter=0;
				InitialieZipper();
				}else{
				if(I<=0){
					I=0;
					autoflag = false;
					zipflag = false;
					}else{
						int a = 1+(int)(((float)(max_zipAnimValue)/I)/2);
						I-=a;

					}
					Debug.Log("Last I"+I);
					if(I<=0){
						I=0;
					}
					spriteRenderer.sprite = sprites[I];
			}
			}
		}
	}

	void InitialieZipper(){
		progress = PROGRESS.NORMAL;
		_zipper_slider.value = 111;
		I=111-(int)_zipper_slider.value;
		zipflag = true;
		autoflag = false;
		AntGameManager.Init ();
	}
}

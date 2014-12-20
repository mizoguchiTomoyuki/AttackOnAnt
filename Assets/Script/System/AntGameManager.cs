using UnityEngine;
using System.Collections;

public static class AntGameManager {

	public static int destroy_AntNum = 0;
	public static float Cake_HP = 100;
	public static float time=60f;
	public static float progcounter = 0;
	public static bool bMute = false;
	public static bool SnipeMode=false;
	public static int ant_num = 0;
	public static bool stflag = false;
	public static  float[] progressCounter = {0,3,0,10,0};
	public static bool reverse= true;
	public static float difficult = 0; //0~1であらわされる難しさの指標. 
	public enum PROGRESS{
		STARTWAIT = 0,
		READYGAME = 1,
		PLAYGAME = 2,
		RESULTGAME = 3,
		ENDGAME = 4,
	};
	public static PROGRESS progress;
	public enum CAKESTATE
	{
		NORMAL = 1,
		DAMAGE_1 = 2,
		DAMAGE_2 = 3,
		DAMAGE_3 = 4,
		DAMAGE_4 = 5,
	};
	public static CAKESTATE cake_state = CAKESTATE.NORMAL;

	static AntGameManager(){
		Init ();
	}

	public static void Init(){
		progress = PROGRESS.STARTWAIT;
		stflag = false;
		destroy_AntNum = 0;
		time = 60f;
		Cake_HP = 100;
		ant_num = 0;
	}
	public static void ProgressStepUP(){
		progcounter = 0;
		switch(progress){
		case PROGRESS.STARTWAIT: 
			Cake_HP = 100;
			cake_state = CAKESTATE.NORMAL;
			progress = PROGRESS.READYGAME;
			break;
		case PROGRESS.READYGAME: 
			progress = PROGRESS.PLAYGAME;
			break;
		case PROGRESS.PLAYGAME:
			progress = PROGRESS.RESULTGAME;
			break;
		case PROGRESS.RESULTGAME:
			progress = PROGRESS.ENDGAME;
			break;
		case PROGRESS.ENDGAME:
			progress = PROGRESS.STARTWAIT;
			break;
		}
	}
	public static void AddAnt(){
		ant_num++;
	}

	public static void DestroyAntAdd(){
		ant_num--;
		destroy_AntNum++;
	}

	public static void CakeEat(float Damage){
		Cake_HP -= Damage;

		if (Cake_HP <= 0) {
						cake_state = CAKESTATE.DAMAGE_4;
				} else if (Cake_HP < 20) {
						cake_state = CAKESTATE.DAMAGE_4;
		} else if (Cake_HP < 40) {
			cake_state = CAKESTATE.DAMAGE_3;

		} else if (Cake_HP < 60) {
			cake_state = CAKESTATE.DAMAGE_2;
			
		} else if (Cake_HP < 80) {
			cake_state = CAKESTATE.DAMAGE_1;
			
		}
	}

	public static int GetTime(){
		return (int)time;
	}
	public static void SetTime(float t){
		time = t;
	}
	
	public static void SetDifficult(float diff){
		difficult = diff;
	}
	public static void TurnReverse(){
		reverse = !reverse;
	}
	public static void TurnSnipe(){
		SnipeMode = !SnipeMode;
	}
	public static Sprite GetSprite(string fileName, string spriteName) {
		Sprite[] sprites = Resources.LoadAll<Sprite>(fileName);
		return System.Array.Find<Sprite>(sprites, (sprite) => sprite.name.Equals(spriteName));
	}
	public static void QuitGame(){
		Application.Quit();
	}

}

﻿using UnityEngine;
using System.Collections;

public static class AntGameManager {

	public static int destroy_AntNum = 0;
	public static float Cake_HP = 100;
	public static float time=60f;
	public static bool bMute = false;
	public static int ant_num = 0;

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
		destroy_AntNum = 0;
		time = 60f;
		Cake_HP = 100;
		ant_num = 0;
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

	public static Sprite GetSprite(string fileName, string spriteName) {
		Sprite[] sprites = Resources.LoadAll<Sprite>(fileName);
		return System.Array.Find<Sprite>(sprites, (sprite) => sprite.name.Equals(spriteName));
	}
}

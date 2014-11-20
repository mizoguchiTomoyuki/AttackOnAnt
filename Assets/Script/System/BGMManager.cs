using UnityEngine;
using System.Collections;


// ゲーム中にならすBGMおよびSEを管理するクラス


public class BGMManager : SingletonObject<BGMManager> {

	// AudioSourceコンポーネント
	// 一つ目に最初に鳴らすサウンドクリップ、２つめに１つめの再生が終わったら鳴らすクリップ 
	// ループ指定しておく事でずっとならす事ができる 
	public GameObject MainLoopBGM = null;
	public float offset = 0.0f;

	// BGM
	public BGMObject[] BGMList;
	// SE
	public AudioSource[] SEList;

	// 
	// Use this for initialization
	void Start () {
#if false

		//int bgm_id = FlightGameManager.BGM_ID;
		//(void)bgm_id;
		int bgm_id = 1;

		// ゲームパラメータ記述オブジェクト.
		LevelItem param = FindObjectOfType<LevelItem>();
		if(param)
		{
			bgm_id = param.BGM_ID;
			offset = param.BGM_offset;
		}
		PlayBGM(bgm_id, offset);
#endif
		// 別のシーンを読んでもこのオブジェクトは削除しない
		DontDestroyOnLoad(gameObject);
	}



	// Update is called once per frame
	void Update () {
		
	}


	// BGMを再生（ループ対応）
	// BGMObjectは
	// 1.最初から最後までのループ再生
	// 2.または頭部分＋ループ部分の２つのAudioSource
	public void PlayBGM(int BGMID)
	{
		PlayBGM(BGMID, 0);
	}
	public void PlayBGM(int BGMID, float _offset)
	{
		//int bgm_id = FlightGameManager.BGM_ID;
		//(void)bgm_id;
		// 今なってるBGMをとめる
		StopBGM();

		if(AntGameManager.bMute) return;

		// BGMを再生する
		int bgm_id = BGMID;
		offset = _offset;

		if(BGMList != null && bgm_id < BGMList.Length)
		{
			BGMObject BGMObj = BGMList[bgm_id];
			if(BGMObj)
			{
				Debug.Log("PlayBGM:"+ BGMID.ToString() + " offset:" + offset.ToString());
				AudioSource[] bgm = BGMObj.GetComponentsInChildren<AudioSource>();
				//Debug.Log(bgm.Length.ToString() + " " + offset.ToString());
				if(bgm.Length >= 1)
				{
					if(offset > 0)
					{
						bgm[0].PlayDelayed(offset);
					}
					else if(offset < 0)
					{
						bgm[0].time = -offset;	// シーク.
						bgm[0].Play();
					}
					else{
						bgm[0].Play();
					}
					if(bgm.Length >= 2)
					{
						bgm[1].PlayDelayed(offset + bgm[0].clip.length);
					}
				}
			}
			MainLoopBGM = BGMObj.gameObject;
		}
	}

	// これを呼び出すととまります。 
	public void StopBGM()
	{
		if(MainLoopBGM != null)
		{
			AudioSource[] bgm = MainLoopBGM.GetComponents<AudioSource>();
			if(bgm.Length >= 1)
			{
				bgm[0].Stop();
				if(bgm.Length >= 2)
				{
					bgm[1].Stop();
				}
			}
			MainLoopBGM = null;
		}
	}

	// こういうのも実装したい（現在未実装） 
	public void StopBGM(float fadeTime)
	{
		StopBGM(); // 仮 
		// コルーチンで簡単に出来そうではある。再生、停止が被ったときの処理が面倒そう. 
	}


	public void PlaySE(int SEID)
	{
		PlaySE(SEID, 0);
	}

	public void PlaySE(int SEID, float delay)
	{
		if(AntGameManager.bMute) return;

		if(SEID >= SEList.Length)
		{
			Debug.Log("Error:PlaySE " + SEID.ToString());
			return;
		}
		AudioSource se = SEList[SEID];
		if(se)
		{
			if(delay>0)
			{
				se.PlayDelayed(delay);
			}
			else
			{
				se.Play();
			}
		}
	}

}

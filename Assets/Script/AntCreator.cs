using UnityEngine;
using System.Collections;

public class AntCreator : MonoBehaviour {
	public GameObject Target;
	public GameObject Escape_P;
	public GameObject Original_Ant;

	public float interval = 1.0f;

	public Camera Main_Camera;
	public int max_Ant = 20;
	public float screen_width, screen_height;

	public int Max_Range=41, Min_Range=0;

	private float enemy_spawn_count = 0;
	private int progress;
	private float[] prog_timer;
	// Use this for initialization
	void Start () {
		if (Target == null) {
			return;
		}
		if (Original_Ant == null) {
			return;
		}
		screen_width = Screen.width;
		screen_height = Screen.height;
	}
	
	// Update is called once per frame
	void Update () {
		if (AntGameManager.progress == AntGameManager.PROGRESS.PLAYGAME) {
		enemy_spawn_count += Time.deltaTime;
		if (AntGameManager.ant_num <= max_Ant) {
						if (enemy_spawn_count > interval) {
								enemy_spawn_count = 0;
								float rand = Random.Range (0, 3f);
								if (rand > 1f) {
										int rand_point = Random.Range (Min_Range, Max_Range);
										Vector3 Enemy_position = GetNumOfAppear (rand_point);
										GameObject TmpAnt = (GameObject)Instantiate (Original_Ant, Enemy_position, Quaternion.identity);
										TmpAnt.AddComponent ("TargetAttack");
										TmpAnt.GetComponent<TargetAttack> ().Target_Cake = Target;
										TmpAnt.GetComponent<TargetAttack> ().EscapePoint = Escape_P;
										TmpAnt.GetComponent<TargetAttack> ().speed = 0.001f;
										AntGameManager.AddAnt();
								}
						}
				}
		}
	
	}
	Vector3 GetNumOfAppear(int n){
		Vector3 Ret_Position = Vector3.zero;
		if (n > 25) {
						float xs = (float)(screen_width * ((25f-n)+16f)) / 16f;
			Ret_Position = new Vector3 (xs, screen_height, 14);
			//Debug.Log(Ret_Position);
		} else if (n > 16) {
						float ys = (float)(screen_height * (n-16f)) / 16f;
			Ret_Position = new Vector3 (screen_width, ys, 14);
			//Debug.Log(Ret_Position);
		} else{
			float xs = (float)(screen_width * n) / 16f;
			Ret_Position = new Vector3 (xs, 0, 14);
			//Debug.Log(Ret_Position);

		}
		return Main_Camera.ScreenToWorldPoint(Ret_Position);
	}
}

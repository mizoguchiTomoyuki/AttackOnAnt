using UnityEngine;
using System.Collections;

public class MouseClickOnAttack : MonoBehaviour {
	public Vector3 Attack_Point = Vector3.zero;
	public float z_point;
	public GameObject AttackImpact;
	private Camera main;
	// Use this for initialization
	void Start () {
		main = GetComponent<Camera> ();
	}
	
	// Update is called once per frame
	void Update () {
	if (Input.GetMouseButtonDown (0)) {
			Attack_Point = main.ScreenToWorldPoint(Input.mousePosition);
			Vector3 AttackTmpPoint = new Vector3 (Attack_Point.x,Attack_Point.y,z_point);
			GameObject Attack = (GameObject)Instantiate(AttackImpact,AttackTmpPoint,Quaternion.identity);
			float mousePos = Input.mousePosition.x;
			Debug.Log (mousePos);
			if(AntGameManager.difficult>0.8){
				
				Attack.GetComponent<ImpactExpand>().imp_range = 0.01f*AntGameManager.ant_num;
			}else{
			if(AntGameManager.reverse){
			if(mousePos<(Screen.width*1.5f)/4f){
			Attack.GetComponent<ImpactExpand>().imp_range = 0.6f;
			}else if(mousePos<(Screen.width*2.5f)/4f){
				Attack.GetComponent<ImpactExpand>().imp_range = 0.9f;
			}else if(mousePos<(Screen.width*3)/4f){
				Attack.GetComponent<ImpactExpand>().imp_range = 1.2f;
			}else{
				Attack.GetComponent<ImpactExpand>().imp_range = 1.2f;
				}
			}else{
				if(mousePos<(Screen.width*1.5f)/4f){
					Attack.GetComponent<ImpactExpand>().imp_range = 1.2f;
				}else if(mousePos<(Screen.width*2.5f)/4f){
					Attack.GetComponent<ImpactExpand>().imp_range = 0.9f;
				}else if(mousePos<(Screen.width*3)/4f){
					Attack.GetComponent<ImpactExpand>().imp_range = 0.6f;
				}else{
					Attack.GetComponent<ImpactExpand>().imp_range = 0.6f;
				}
			}
			}

		}
	}
}

using UnityEngine;
using System.Collections;
//参考 http://nextsystemkinectblog.seesaa.net/article/358368717.html. 
public class ParticleAliveCheck : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void LateUpdate (){
		//このゲームオブジェクトのパーティクルが生存しているかどうか.
		if(!particleSystem.IsAlive()){
			Destroy (gameObject);
		}
	}	
}

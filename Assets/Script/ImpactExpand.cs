using UnityEngine;
using System.Collections;

public class ImpactExpand : MonoBehaviour {
	CircleCollider2D ColliderCircle;
	public float imp_speed = 0.01f;
	public float imp_range = 1.2f;
	// Use this for initialization
	void Start () {
		ColliderCircle = GetComponent<CircleCollider2D> ();
		ColliderCircle.radius = 0.1f;
	}
	
	// Update is called once per frame
	void Update () {
		if (ColliderCircle.radius < imp_range) {
						ColliderCircle.radius += imp_speed;
				} else {
			this.Destroy(this.gameObject);
				}
	}
}

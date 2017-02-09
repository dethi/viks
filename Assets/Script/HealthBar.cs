using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {

	private Camera player;

	void Start() {
		player = GameObject.Find("Player").GetComponent<Camera>();
	}
	
	void Update () {
		transform.LookAt(transform.position + player.transform.rotation * Vector3.forward,
			player.transform.rotation * Vector3.up);
	}
}

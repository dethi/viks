using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TowerManager : MonoBehaviour {

	private float relativeHeightToHealth;
	private float initialY;

	private Health hc;

	void Start () {
		hc = GetComponent<Health> ();
		if (hc == null) {
			throw new MissingComponentException("Missing Health component");
		}

		float initialHeigth = GetComponent<Renderer>().bounds.size.y;
		relativeHeightToHealth = initialHeigth / (float)hc.maxHealth;
		initialY = transform.position.y;
	}
	
	void Update () {
		transform.position = new Vector3 (
			transform.position.x,
			initialY - ((hc.maxHealth - hc.health) * relativeHeightToHealth),
			transform.position.z
		);
	}
}

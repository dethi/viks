using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TowerHealth : MonoBehaviour, IHealth {

	public Slider healthSlider;
	private float relativeHeightToHealth;
	private float initialY;

	public int maxHealth;

	private int _health;
	private int health {
		get {
			return _health;
		}
		set {
			_health = (value > 0) ? value : 0;
		}
	}

	void Start () {
		health = maxHealth;
		healthSlider.maxValue = maxHealth;

		float initialHeigth = GetComponent<Renderer>().bounds.size.y;
		relativeHeightToHealth = initialHeigth / (float)maxHealth;
		initialY = transform.position.y;
	}
	
	void LateUpdate () {
		healthSlider.value = health;

		transform.position = new Vector3 (
			transform.position.x,
			initialY - ((maxHealth - health) * relativeHeightToHealth),
			transform.position.z
		);
	}

	public void DecrementHealthBy (int v) {
		health -= v;
	}
}

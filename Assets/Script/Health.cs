using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface IHealth {
	void DecrementHealthBy (int v);
}

public class Health : MonoBehaviour {

	public Slider slider;
	public int maxHealth;

	private int _health;
	public int health {
		get {
			return _health;
		}
		private set {
			_health = (value > 0) ? value : 0;
		}
	}

	void Start () {
		health = maxHealth;
		if (slider)
			slider.maxValue = maxHealth;
	}

	void LateUpdate () {
		if (slider)
			slider.value = health;
	}

	public void DecrementHealthBy (int v) {
		health -= v;
	}
}
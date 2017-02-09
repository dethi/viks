using System;
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

    private bool _alive = true;
    public bool alive
    {
        get
        {
            return _alive;
        }
        private set
        {
            _alive = value;
        }
    }

    private Action _deadCallback = () => { return; };
    public Action deadCallback
    {
        get
        {
            return _deadCallback;
        }
        set
        {
            _deadCallback = value;
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

        if (health == 0 && alive)
        {
            alive = false;
            deadCallback();
        }
	}

	public void DecrementHealthBy (int v) {
        health -= v;
    }
}
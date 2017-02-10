using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour {

    public Vector3 rotationVector = new Vector3(-90, 0, 0);
    public Vector3 hitpoint = new Vector3(0, 0, 0);
    public int damage = 40;
    public int lifeTime = 3;

    private Collider _collider;
    private bool _use = false;

    // Use this for initialization
    void Start () {
        _collider = GetComponent<Collider>();
        Destroy(gameObject, lifeTime);
	}
	
    void LateUpdate()
    {
        if (_use)
            _collider.enabled = false;
    }

    void OnTriggerEnter(Collider other)
    {
        _use = true;
        if (other.CompareTag("Warrior") || other.CompareTag("Caravel"))
        {
            other.GetComponent<Health>().DecrementHealthBy(damage);
        }
    }
}

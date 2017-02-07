using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Kill : MonoBehaviour {

    void OnCollisionEnter(Collision col) {
        if (col.gameObject.name.Contains("Warrior")) {
            col.gameObject.GetComponent<WarriorController>().Dead();
        }

        if (col.gameObject.CompareTag("Caravel"))
        {
            col.gameObject.GetComponent<CaravelController>().Dead();
        }

        Destroy(gameObject);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Kill : MonoBehaviour {

    void OnCollisionEnter(Collision col) {
        if (col.gameObject.name.Contains("Warrior")) {
            Animator animator = col.gameObject.GetComponent<Animator>();
            NavMeshAgent agent = col.gameObject.GetComponent<NavMeshAgent>();
            animator.SetBool("Dead", true);
            agent.Stop();
        }

        Destroy(gameObject);
    }
}
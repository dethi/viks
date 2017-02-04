using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kill : MonoBehaviour {

    void OnCollisionEnter(Collision col){
        Debug.Log(col.gameObject.name);

        if (col.gameObject.name.Contains("Warrior")){
            Animator animator = col.gameObject.GetComponent<Animator>();
            UnityEngine.AI.NavMeshAgent agent = col.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
            animator.SetBool("Dead", true);
            agent.Stop();
            Destroy(col.gameObject, 1);
        }


        Destroy(gameObject);
    }
}

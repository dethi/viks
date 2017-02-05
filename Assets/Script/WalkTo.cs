using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkTo : MonoBehaviour {

    public Transform goal;

    void Start()
    {
        UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.destination = goal.position;
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, goal.transform.position) < 4.5)
        {
            Animator animator = GetComponent<Animator>();
            UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
            agent.Stop();
            animator.SetBool("Attacking", true);
        }
    }

    void Attack()
    {
        Debug.Log("Attack");
        goal.transform.Translate(new Vector3(0, 0, -0.1f));
    }

    void Disapear()
    {
        Destroy(gameObject, 2);
    }
}
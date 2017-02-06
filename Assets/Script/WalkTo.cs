using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class WalkTo : MonoBehaviour {

    public Transform goal;
    public Slider health;

	private NavMeshAgent agent;
	private Animator animator;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position;

		animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, goal.transform.position) < 20)
        {
            agent.Stop();
            animator.SetBool("Attacking", true);
        }
    }

    void Attack()
    {
        Debug.Log("Attack");
        goal.transform.Translate(new Vector3(0, 0, -0.1f));
        health.value -= 5;
    }

    void Disapear()
    {
        Destroy(gameObject, 2);
    }
}
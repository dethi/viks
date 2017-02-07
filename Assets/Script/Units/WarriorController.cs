using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class WarriorController : MonoBehaviour {
    
	private NavMeshAgent agent;
	private Animator animator;
    private Health health;

    private Transform goal;

    void Start () {
        agent = GetComponent<NavMeshAgent>();
		animator = GetComponent<Animator>();
        health = GetComponent<Health>();
        health.deadCallback = Dead;
    }

	void Update () {
        if (goal && Vector3.Distance(transform.position, goal.transform.position) < 20)
        {
            agent.Stop();
            animator.SetBool("Attacking", true);
        }
    }

    public void SetGoal (Transform plop) {
        this.goal = plop;
        agent = GetComponent<NavMeshAgent>();
        agent.destination = plop.position;
    }

    public void Dead ()
    {
        animator.SetBool("Dead", true);
        agent.Stop();
    }

    void Attack () {
		goal.GetComponent<Health>().DecrementHealthBy(5);
    }

    void Disapear () {
        Destroy(gameObject, 2);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class WalkTo : MonoBehaviour {
    
    public Slider health;

	private NavMeshAgent agent;
	private Animator animator;
    private Transform goal;

    void Start () {
        agent = GetComponent<NavMeshAgent>();
		animator = GetComponent<Animator>();
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

    void Attack () {
		goal.GetComponent<IHealth>().DecrementHealthBy(5);
    }

    void Disapear () {
        Destroy(gameObject, 2);
    }
}
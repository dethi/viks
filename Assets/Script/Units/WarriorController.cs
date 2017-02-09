using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class WarriorController : MonoBehaviour
{

    private NavMeshAgent agent;
    private Animator animator;
    private Collider _collider;
    private Health health;

    private Transform goal;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        health = GetComponent<Health>();
        _collider = GetComponent<Collider>();
        health.deadCallback = Dead;
    }

    void Update()
    {
        if (goal && Vector3.Distance(transform.position, goal.transform.position) < 10)
        {
            agent.Stop();
            animator.SetBool("Attacking", true);
        }
    }

    public void SetGoal(Transform plop)
    {
        this.goal = plop;
        GetComponent<Animator>().SetBool("Attacking", false);
        agent = GetComponent<NavMeshAgent>();
        agent.destination = plop.position;
    }

    public void Dead()
    {
        animator.SetBool("Dead", true);
        _collider.enabled = false;
        agent.Stop();
    }

    void Attack()
    {
        if (goal && Vector3.Distance(transform.position, goal.transform.position) > 15)
        {
            animator.SetBool("Attacking", false);
            return;
        }

        Health gh = goal.GetComponent<Health>();
        if (gh)
            gh.DecrementHealthBy(5);
    }

    void Disapear()
    {
        Destroy(gameObject, 2);
    }
}
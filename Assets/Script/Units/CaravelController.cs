using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CaravelController : MonoBehaviour
{
    private Transform goal;
    private NavMeshAgent agent;
    private Health health;

    private DockingDockController dockController;

    private bool arrived = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        health = GetComponent<Health>();
        health.deadCallback = Dead;
    }

    public void setGoal(DockingDockController newdockController)
    {
        agent = GetComponent<NavMeshAgent>();
        dockController = newdockController;

        goal = dockController.transform;
        agent.destination = goal.position;
    }

    void OnTriggerEnter(Collider other)
    {
        if (!arrived && other.CompareTag("Docking Dock"))
        {
            agent.Stop();
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            arrived = true;
        }
    }

    public void Dead ()
    {
        SendMessageUpwards("AddScore", 60);

        if (dockController)
            dockController.unRegisterShip();

        Destroy(gameObject);
    }
}

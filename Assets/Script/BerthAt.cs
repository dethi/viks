using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BerthAt : MonoBehaviour {

	public Transform goal;

	private NavMeshAgent agent;

	void Start() {
		agent = GetComponent<NavMeshAgent>();
		agent.destination = goal.position;
	}

	void OnTriggerEnter(Collider other) {
		if (other.CompareTag("Docking Dock")) {
			agent.Stop();
		}
	}
}
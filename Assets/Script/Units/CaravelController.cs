using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CaravelController : MonoBehaviour
{
    public Transform goal;
    public GameObject soldierPrefab;
    public GameObject orkPrefab;
    public Transform soldierGoal;

    public float delaySpawn = 1f;
    private float delayTimer = 0;

    private Transform spawnPoint;
    private NavMeshAgent agent;

    private bool arrived = false;
    private bool spawning = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position;
    }

    void Update()
    {
        if (spawning)
        {
            SpawnMob();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (!arrived && other.CompareTag("Docking Dock"))
        {
            agent.Stop();
            GetComponent<Rigidbody>().detectCollisions = false;
            StartSpawn(other.gameObject.transform.parent);
            arrived = true;
        }
    }

    public void StartSpawn(Transform port)
    {
        PrepareSpawnPoint(port);
        spawning = true;
    }

    public void PrepareSpawnPoint(Transform port)
    {
        foreach (Transform child in port)
        {
            if (child.CompareTag("Spawn Point"))
            {
                spawnPoint = child;
                return;
            }
        }
    }

    public void SpawnMob()
    {
        delayTimer += Time.deltaTime;
        if (delayTimer > delaySpawn)
        {
            float rand = Random.Range(0f, 1f);

            if (rand < 0.7f)
            {
                GameObject soldier = Instantiate(soldierPrefab, spawnPoint.position, Quaternion.identity) as GameObject;
                WalkTo script = soldier.GetComponent<WalkTo>();
                script.SetGoal(soldierGoal);
            }

            if (rand > 0.9f)
            {
                GameObject soldier = Instantiate(orkPrefab, spawnPoint.position, Quaternion.identity) as GameObject;
                WalkTo script = soldier.GetComponent<WalkTo>();
                script.SetGoal(soldierGoal);
            }

            
            delayTimer = 0f;
        }
    }
}

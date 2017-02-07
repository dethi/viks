using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GameManager : MonoBehaviour {

    public GameObject soldierPrefab;

    public Transform goal;
    public Transform army;

    private SpawnPoint[] spawnPoints;

    // Use this for initialization
    void Start ()
    {
        spawnPoints = GetComponentsInChildren<SpawnPoint>();
    }
	
	// Update is called once per frame
	void Update () {
		foreach (SpawnPoint spawnPoint in spawnPoints)
        {
            if (spawnPoint.canSpawn())
            {
                spawnPoint.spawn(soldierPrefab, (GameObject obj) =>
                {
                    obj.GetComponent<WalkTo>().SetGoal(goal);
                    obj.transform.LookAt(goal);
                    obj.transform.parent = army;
                });
            }
        }
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GameManager : MonoBehaviour {

    public GameObject soldierPrefab;

    private Transform _goal;
    public Transform lighthouse;
    public Transform firstGate;
    public Transform army;

    private SpawnPoint[] spawnPoints;

    // Use this for initialization
    void Start ()
    {
        spawnPoints = GetComponentsInChildren<SpawnPoint>();
        _goal = firstGate;
    }
	
	// Update is called once per frame
	void Update () {
		foreach (SpawnPoint spawnPoint in spawnPoints)
        {
            if (spawnPoint.canSpawn())
            {
                spawnPoint.spawn(soldierPrefab, (GameObject obj) =>
                {
                    obj.GetComponent<WarriorController>().SetGoal(_goal);
                    obj.transform.LookAt(_goal);
                    obj.transform.parent = army;
                });
            }
        }
	}

    void TowerDestroy(string towerName)
    {
        Debug.Log("TowerDestroy: " + towerName);
        _goal = lighthouse;

        if (towerName == firstGate.name)
        {
            foreach (Transform child in army)
            {
                WarriorController warriorController = child.GetComponent<WarriorController>();
                if (warriorController)
                {
                    warriorController.SetGoal(_goal);
                }
            }
        }
    }
}

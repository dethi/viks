﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public GameObject soldierPrefab;
    public GameObject orcPrefab;

    public GameObject gameOver;

    private Transform _goal;
    public Transform lighthouse;
    public Transform firstGate;
    public Transform mountainGate;
    public Transform army;

    int goal_state = 0; // 0: beach / 1: moutain / 2goal

    private SpawnPoint[] spawnPoints;

    // Use this for initialization
    void Start ()
    {
        gameOver.SetActive(false);
        spawnPoints = GetComponentsInChildren<SpawnPoint>();
        _goal = firstGate;
    }
	
	// Update is called once per frame
	void Update () {
		foreach (SpawnPoint spawnPoint in spawnPoints)
        {
            if (spawnPoint.canSpawn())
            {
                GameObject prefab = soldierPrefab;
                if (spawnPoint.getTypeSoldier() == "orc")
                    prefab = orcPrefab;

                spawnPoint.spawn(prefab, (GameObject obj) =>
                {
                    Transform newGoal = getGoal();
                    obj.GetComponent<WarriorController>().SetGoal(newGoal);
                    obj.transform.LookAt(newGoal);
                    obj.transform.parent = army;
                });
            }
        }
	}

    Transform getGoal()
    {
        if (goal_state == 0)
            return firstGate;
        if (goal_state == 1)
        {
            if (Random.Range(0f, 1f) > 0.7f)
                return mountainGate;
            else
                return lighthouse;
        }

        return lighthouse;
    }

    void Restart()
    {
        SceneManager.LoadScene("main");
    }

    void TowerDestroy(string towerName)
    {
        if (towerName == lighthouse.name)
        {
            gameOver.SetActive(true);
            Invoke("Restart", 3);
            return;
        }

        if (towerName == mountainGate.name)
        {
            goal_state = 2;

            foreach (Transform child in army)
            {
                WarriorController warriorController = child.GetComponent<WarriorController>();
                if (warriorController)
                {
                    warriorController.SetGoal(getGoal());
                }
            }
            return;
        }

        if (towerName == firstGate.name)
        {
            goal_state = 1;

            foreach (Transform child in army)
            {
                WarriorController warriorController = child.GetComponent<WarriorController>();
                if (warriorController)
                {
                    warriorController.SetGoal(getGoal());
                }
            }
            return;
        }
    }
}

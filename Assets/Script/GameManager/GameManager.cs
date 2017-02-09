using System.Collections;
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
    public Transform army;

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
                if (Random.Range(0f, 1f) < 0.1f)
                    prefab = orcPrefab;

                spawnPoint.spawn(prefab, (GameObject obj) =>
                {
                    obj.GetComponent<WarriorController>().SetGoal(_goal);
                    obj.transform.LookAt(_goal);
                    obj.transform.parent = army;
                });
            }
        }
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
            return;
        }
    }
}

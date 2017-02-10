using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour {

    public string _type;

    private bool _spawning = false;
    private bool _canSpawn = false;

    private float _spawnTimer = 0f;
    private float _spawnDelay;
    private float _spawnDelayMin;
    private float _difficultyTimer = 0f;
    private bool _increase = false;

	// Use this for initialization
	void Start () {
        _spawnDelay = (_type == "warrior" ? Constant.SOLDIER_SPAWN_DELAY : Constant.ORC_SPAWN_DELAY);
        _spawnDelayMin = (_type == "warrior" ? Constant.SOLDIER_SPAWN_DELAY_MIN : Constant.ORC_SPAWN_DELAY_MIN);
    }
	
	// Update is called once per frame
	void Update () {
		if (_spawning && !_canSpawn)
        {
            _spawnTimer += Time.deltaTime;
            if (_spawnTimer > _spawnDelay)
            {
                _canSpawn = true;
                _spawnTimer = 0f;
            }
        }
        if (_increase)
        {
            _difficultyTimer += Time.deltaTime;
            if (_difficultyTimer > Constant.TIMER_INCREASE_DIFFICULTY)
            {
                _spawnDelay = Math.Max(_spawnDelayMin, _spawnDelay - 0.2f);
                _difficultyTimer = 0f;
            }
        }
    }

    public string getTypeSoldier()
    {
        return _type;
    }

    public void spawn(GameObject prefab, Action<GameObject> init)
    {
        if (!_canSpawn)
            return;

        GameObject newObj = Instantiate(prefab, transform.position, Quaternion.identity) as GameObject;
        init(newObj);

        _canSpawn = false;
    }

    public bool canSpawn()
    {
        return _canSpawn;
    }

    public void setSpawning(bool spawning)
    {
        _increase = true;
        _spawning = spawning;
        _canSpawn = spawning;
        if (!spawning)
            _spawnTimer = 0f;
    }
}
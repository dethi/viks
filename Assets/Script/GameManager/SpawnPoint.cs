﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour {
    
    private bool _spawning = false;
    private bool _canSpawn = false;
    private float _spawnTimer = 0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (_spawning && !_canSpawn)
        {
            _spawnTimer += Time.deltaTime;
            if (_spawnTimer > Constant.SOLDIER_SPAWN_DELAY)
            {
                _canSpawn = true;
                _spawnTimer = 0f;
            }
        }
	}

    public void spawn(GameObject prefab, Transform parent, Action<GameObject> init)
    {
        if (!_canSpawn)
            return;

        GameObject newObj = Instantiate(prefab, transform.position, Quaternion.identity) as GameObject;
        newObj.transform.parent = parent;
        init(newObj);

        _canSpawn = false;
    }

    public bool canSpawn()
    {
        return _canSpawn;
    }

    public void setSpawning(bool spawning)
    {
        _spawning = spawning;
        if (!spawning)
        {
            _canSpawn = false;
            _spawnTimer = 0f;
        }
    }
}
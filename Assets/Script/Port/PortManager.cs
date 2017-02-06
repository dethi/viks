using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortManager : MonoBehaviour {

    public float spawnDelay = 4f;
    private float spawnTimer = 0f;
    
    public GameObject shipPrefab;
    private DockingDockController[] docks;

	// Use this for initialization
	void Start ()
    {
        docks = GetComponentsInChildren<DockingDockController>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer > spawnDelay)
        {
            SpawnShip();
            spawnTimer = 0;
        }
	}

    void SpawnShip()
    {
        List<DockingDockController> freeDocks = new List<DockingDockController>();

        foreach (DockingDockController dock in docks)
            if (!dock.isUse())
                freeDocks.Add(dock);

        if (freeDocks.Count == 0)
            return;

        DockingDockController freeDock = freeDocks[Random.Range(0, freeDocks.Count)];

        GameObject newShip = Instantiate(shipPrefab, freeDock.getSpawnPoint().position, Quaternion.identity) as GameObject;
        newShip.transform.LookAt(freeDock.transform);
        newShip.transform.parent = transform;

        CaravelController controller = newShip.GetComponent<CaravelController>();
        controller.setGoal(freeDock);
        freeDock.registerShip(controller);
    }
}

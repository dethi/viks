using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortManager : MonoBehaviour {
    
    private float shipSpawnTimer = 0f;
    
    public Transform army;
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
        shipSpawnTimer += Time.deltaTime;
        if (shipSpawnTimer > Constant.SHIP_SPAWN_DELAY)
        {
            SpawnShip();
            shipSpawnTimer = 0;
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

        GameObject newShip = Instantiate(shipPrefab, freeDock.getShipSpawnPoint().position, Quaternion.identity) as GameObject;
        newShip.transform.LookAt(freeDock.transform);
        newShip.transform.parent = army;

        CaravelController controller = newShip.GetComponent<CaravelController>();
        controller.setGoal(freeDock);
        freeDock.registerShip(controller);
    }
}

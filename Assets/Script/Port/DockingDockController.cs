using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DockingDockController : MonoBehaviour {

    public Transform shipSpawnPoint;
    public Transform soldierSpawnPointTransform;

    private SpawnPoint soldierSpawnPoint;

    private CaravelController caravel;
    private bool use = false;


    // Use this for initialization
    void Start()
    {
        soldierSpawnPoint = soldierSpawnPointTransform.GetComponent<SpawnPoint>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Caravel"))
        {
            soldierSpawnPoint.setSpawning(true);
        }
    }

    public Transform getShipSpawnPoint()
    {
        return shipSpawnPoint;
    }

    public bool isUse()
    {
        return use;
    }
    
    public void registerShip(CaravelController newCaravel)
    {
        use = true;
        caravel = newCaravel;
    }

    public void unRegisterShip()
    {
        use = false;
        caravel = null;
        soldierSpawnPoint.setSpawning(false);
    }
}

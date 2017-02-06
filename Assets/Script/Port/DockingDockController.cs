using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DockingDockController : MonoBehaviour {

    public Transform spawnPoint;

    private CaravelController caravel;
    private bool use = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Caravel"))
        {
            use = true;
        }
    }

    public Transform getSpawnPoint()
    {
        return spawnPoint;
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
    }
}

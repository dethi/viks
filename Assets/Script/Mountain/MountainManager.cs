using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountainManager : MonoBehaviour {

    public SpawnPoint orcSpawnPoint;

    void UnlockGate ()
    {
        orcSpawnPoint.setSpawning(true);
    }
}

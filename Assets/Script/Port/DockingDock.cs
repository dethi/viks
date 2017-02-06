using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DockingDock : MonoBehaviour {
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Caravel"))
        {
            //Debug.Log("DockingDock: Collider");
        }
    }
}

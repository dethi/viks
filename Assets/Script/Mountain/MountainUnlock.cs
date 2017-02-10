using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountainUnlock : MonoBehaviour {

	void OnDestroy()
    {
        SendMessageUpwards("UnlockGate");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortManager : MonoBehaviour {
    private List<GameObject> children;

	// Use this for initialization
	void Start () {
        children = new List<GameObject>();
        foreach (Transform child in transform)
        {
            if (child.tag == "Port Dock")
            {
                children.Add(child.gameObject);
            }
        }

        Debug.Log(children);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

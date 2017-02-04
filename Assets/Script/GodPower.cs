using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodPower : MonoBehaviour {

    Ray ray;
    RaycastHit hit;
    public GameObject fireBallPrefab;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                GameObject obj = Instantiate(fireBallPrefab, new Vector3(hit.point.x, 20, hit.point.z), Quaternion.identity) as GameObject;
                obj.transform.Rotate(new Vector3(90, 0, 0));
                obj.transform.parent = transform;
            }

        }
    }
}

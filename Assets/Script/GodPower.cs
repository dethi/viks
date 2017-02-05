using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodPower : MonoBehaviour {

    public GameObject fireBallPrefab;
    public Transform spells;

	private Vector3 rotationVector = new Vector3(90, 0, 0);
	
	void Update() {
		if (Input.GetKeyDown (KeyCode.Mouse0)) {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast(ray, out hit)) {
				GameObject obj = Instantiate(fireBallPrefab, new Vector3(hit.point.x, 20, hit.point.z), Quaternion.identity) as GameObject;
				obj.transform.Rotate(rotationVector);
                obj.transform.parent = spells;
			}
		}
    }
}
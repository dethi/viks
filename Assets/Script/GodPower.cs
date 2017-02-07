using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodPower : MonoBehaviour {

    public Texture2D cursorTexture;
 
    public GameObject fireBallPrefab;
    public GameObject thunderPrefab;
    public Transform spells;

    private Vector3 rotationVector = new Vector3(-90, 0, 0);

    void Update() {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;

		if (Physics.Raycast(ray, out hit)) {

            if (hit.transform.CompareTag("Warrior") || hit.transform.CompareTag("Caravel"))
            {
                Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
            }
            else
            {
                Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
            }

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                GameObject obj = Instantiate(fireBallPrefab, Vector3.zero, Quaternion.identity) as GameObject;
                Spell spell = obj.GetComponent<Spell>();
                spell.transform.position = hit.point + spell.hitpoint;
                obj.transform.Rotate(spell.rotationVector);
                obj.transform.parent = spells;
            }

            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                GameObject obj = Instantiate(thunderPrefab, Vector3.zero, Quaternion.identity) as GameObject;
                Spell spell = obj.GetComponent<Spell>();
                spell.transform.position = hit.point + spell.hitpoint;
                obj.transform.Rotate(spell.rotationVector);
                obj.transform.parent = spells;
            }
        }
    }
}
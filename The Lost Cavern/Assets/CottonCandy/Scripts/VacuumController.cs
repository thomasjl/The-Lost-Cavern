using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VacuumController : MonoBehaviour {

	private float distanceToObj;
	private int RAYCASTLENGTH = 5;
	private Rigidbody attachedObject;

	public CursorMode cursorMode = CursorMode.Auto;
	public Vector2 hotSpot = new Vector2(16, 16);	// Offset du centre du curseur

	public int sugarInventory = 0;
	// Use this for initialization
	void Start () 
	{
		distanceToObj = -1;	
		Cursor.visible = true;
	}
	
	void Update () {
		AspiratorBlower ();
	}

	void AspiratorBlower () {
		RaycastHit hitInfo;
		Ray ray = GetComponentInChildren<Camera>().ScreenPointToRay(Input.mousePosition);
		Debug.DrawRay (ray.origin, ray.direction * RAYCASTLENGTH, Color.blue);
		bool rayCasted = Physics.Raycast (ray, out hitInfo, RAYCASTLENGTH);
		if (Input.GetMouseButton (0)) {
			if (rayCasted && hitInfo.transform.CompareTag ("Suggarable")) {
				Destroy (hitInfo.collider.gameObject);
				SugarGenerator.sugarCounter--;
				ManageSugar ();
			} else if (rayCasted && hitInfo.transform.CompareTag ("CandyMachine")) {
				Debug.Log("Ce n'est pas encore le moment, récupère des sucres!");
			}
		}
	}
		
	void ManageSugar () {
		sugarInventory++;
	}

	void displayNumberSugar () {

	}
}

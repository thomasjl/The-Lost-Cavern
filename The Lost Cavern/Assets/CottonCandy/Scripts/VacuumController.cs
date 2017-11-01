using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VacuumController : MonoBehaviour {

	private float distanceToObject;
	public const int RAYCASTLENGTH = 10;
	public CursorMode cursorMode = CursorMode.Auto;
	public Vector2 hotSpot = new Vector2(16,16);
	public Texture2D cursorOff, cursorDragged, cursorDraggable;
	// Use this for initialization
	void Start () {
		distanceToObject = -1;
		Cursor.SetCursor (cursorOff, hotSpot, cursorMode);
		Cursor.visible = true;
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hitInfo;
		// Ray ray = GetComponentInChildren<Camera> ().ScreenPointToRay (Input.mousePosition);
		Debug.DrawRay (this.transform.position, this.transform.forward * RAYCASTLENGTH, Color.blue);
		bool rayCasted = Physics.Raycast (this.transform.position, this.transform.forward, out hitInfo, RAYCASTLENGTH);
		if (rayCasted && hitInfo.transform.CompareTag ("Suggarable")) {
			if (Input.GetMouseButtonDown (0)) {
				Destroy (hitInfo.collider.gameObject);
				Debug.Log ("Sugar obtenu");
			}
		}
	}
}

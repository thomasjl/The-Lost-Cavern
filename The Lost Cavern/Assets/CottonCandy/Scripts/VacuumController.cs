using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VacuumController : MonoBehaviour {
    
	private Rigidbody attachedObject;

	public CursorMode cursorMode = CursorMode.Auto;
	public Vector2 hotSpot = new Vector2(16, 16);	// Offset du centre du curseur

    private bool canBlowSugar;
    private GameObject sugarTarget;

	void Start () 
	{
		Cursor.visible = true;
        canBlowSugar = false;
	}
	
	void Update () {
		//AspiratorBlower ();
        if (sugarTarget != null)
        {
            if (canBlowSugar && Input.GetMouseButtonDown(0))
            {
                sugarTarget.transform.localScale -= (sugarTarget.transform.localScale * 80/100) * Time.deltaTime;
                //sugarTarget.GetComponent<Sugar>().vacuumEntry = gameObject;
            }

            if (canBlowSugar && Input.GetMouseButton(0))
            {
                sugarTarget.transform.localScale -= (sugarTarget.transform.localScale * 80/100) * Time.deltaTime;
                //sugarTarget.GetComponent<Sugar>().vacuumEntry = gameObject;
            }
        }


	}

    void OnTriggerEnter (Collider other)
    {
        if (other.tag == "Suggarable")
        {
            Debug.Log("sugar detected");

            sugarTarget = other.gameObject;
            //diminue la taille du sucre
            canBlowSugar = true;
           
        }
    }

    void OnTriggerExit ()
    {
        if (canBlowSugar)
        {
            canBlowSugar = false;
        }
    }
}

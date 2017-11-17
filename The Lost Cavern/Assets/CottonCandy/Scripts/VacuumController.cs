using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VacuumController : MonoBehaviour {
       
   // public float aspirationSpeed;

	private float distanceToObj;
	private int RAYCASTLENGTH = 5;
	private Rigidbody attachedObject;

	public CursorMode cursorMode = CursorMode.Auto;
	public Vector2 hotSpot = new Vector2(16, 16);	// Offset du centre du curseur

	public int sugarInventory = 0;	

    private bool canBlowSugar;
    private GameObject sugarTarget;

	void Start () 
	{
		distanceToObj = -1;	
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

	void AspiratorBlower () {

        /*
		RaycastHit hitInfo;
       // Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
        Ray ray = new Ray(transform.position, transform.forward);

		Debug.DrawRay (ray.origin, ray.direction * RAYCASTLENGTH, Color.blue);
		bool rayCasted = Physics.Raycast (ray, out hitInfo, RAYCASTLENGTH);
		if (Input.GetMouseButton (0)) {
			if (rayCasted && hitInfo.transform.CompareTag ("Suggarable")) {
                
				//Destroy (hitInfo.collider.gameObject);
				//SugarGenerator.sugarCounter--;
				//ManageSugar ();

                //diminue la taille du sucre
                GameObject sugar = hitInfo.transform.gameObject;

                //reduction de la taille du sucre
                sugar.transform.localScale -= (sugar.transform.localScale * 80/100) * Time.deltaTime;
                sugar.GetComponent<Sugar>().vacuumEntry = gameObject;

                //sucre se rapproche de l'aspirateur
               // Vector3 dir = transform.position - sugar.transform.position;
                //sugar.transform.Translate(dir.normalized * Time.deltaTime * aspirationSpeed, Space.World);


			} else if (rayCasted && hitInfo.transform.CompareTag ("CandyMachine")) {
				Debug.Log("Ce n'est pas encore le moment, récupère des sucres!");
			}
		}
  */    
	}
		
	void ManageSugar () {
		sugarInventory++;
	}

	void displayNumberSugar () {

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

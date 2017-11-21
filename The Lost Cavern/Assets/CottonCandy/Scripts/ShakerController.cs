using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakerController : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton(0))
		{
			transform.Rotate(Vector3.forward * Time.deltaTime * 200);
		}

		if (Input.GetMouseButton(1))
		{
			transform.Rotate(Vector3.back * Time.deltaTime * 200);
		}


	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "CandyMachine")
		{
			
		}
		else {
			Debug.Log("Pas prêt");
		}
	}
}

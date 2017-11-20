using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SugarFillBehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y <= 0.6)
		{
			Destroy(gameObject);
		}
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "SugarFilled")
		{
			other.transform.position += new Vector3(0, 0.0005f, 0);
		}
	}
}

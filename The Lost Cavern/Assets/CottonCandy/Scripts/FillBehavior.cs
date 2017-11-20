using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillBehavior : MonoBehaviour {

	public static bool fillEnough = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y > 1.18f)
			goalFill();
	}


	public static void goalFill()
	{
		fillEnough = true;
	}
}

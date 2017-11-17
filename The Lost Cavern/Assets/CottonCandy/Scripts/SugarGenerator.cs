﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SugarGenerator : MonoBehaviour {

	const int NUMBEROFSUGARS = 20;
	public static int sugarCounter;
	public GameObject plane;
	public GameObject sugar;
	Bounds planeBounds;
	public Vector3 sugarSize;


	// Use this for initialization
	void Start () {
		sugarCounter = 0;
		planeBounds = plane.GetComponent<Renderer> ().bounds;
		sugarSize = sugar.GetComponent<Renderer> ().bounds.size;
	}

	// Update is called once per frame
	void Update () {
		if (sugarCounter < NUMBEROFSUGARS) {
			float x = Random.Range (planeBounds.min.x + 1, planeBounds.max.x);
			float y = Random.Range (1f, 2f);
			float z = Random.Range (planeBounds.min.z + 1, planeBounds.max.z -1);
			Vector3 sugarPosition = new Vector3 (x, y, z);
			Debug.Log("Création d'un sucre en ("+ x + "," + y + "," + z +")");
			Instantiate(sugar, sugarPosition, Quaternion.identity);
			sugarCounter++;
		}
	}

	public void getSugar() {
		sugarCounter--;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SugarGenerator : MonoBehaviour {

	const int NUMBEROFSUGARS = 4;
	private int sugarCounter;
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
			float x = Random.Range (planeBounds.min.x, planeBounds.max.x *2);
			float y = planeBounds.max.y + sugarSize.y / 2;
			float z = Random.Range (planeBounds.min.z, planeBounds.max.z);
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

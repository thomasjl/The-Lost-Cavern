using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakerFill : MonoBehaviour {
	public GameObject himself;
	public GameObject sugarModel;
	private float sugarDropTimer = 0;
	private bool inTimer = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (inTimer)
		{
			sugarDropTimer -= Time.deltaTime;
			if (sugarDropTimer <= 0)
			{
				inTimer = false;
			}
		}
		if (transform.rotation.eulerAngles.z >= 55 && transform.rotation.eulerAngles.z <= 120)
		{
			Vector3 basePosition = gameObject.transform.GetChild(0).transform.position;
			Instantiate(sugarModel, basePosition, Quaternion.identity);

			inTimer = true;
			// timer de 0.1 secondes
			sugarDropTimer = 0.1f;
		}
		if (FillBehavior.fillEnough == true)
		{
			himself.SetActive(false);
		}
	}
}

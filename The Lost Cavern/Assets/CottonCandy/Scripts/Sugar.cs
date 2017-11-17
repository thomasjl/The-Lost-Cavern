using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sugar : MonoBehaviour {

    private GameObject blowerEntry;
    private bool isDisappearing;

    void Start ()
    {
        isDisappearing = false;
        blowerEntry = GameObject.FindGameObjectWithTag("Blower");
    }

    void Update()
    {        
        if (isDisappearing)
        {
            //calcul distance entre le sucre et l'entre de l'aspirateur (si suffisament approche, detruit)

            float distanceFromBlower = Vector3.Distance(transform.position, blowerEntry.transform.position);
            if (distanceFromBlower <= 0.1f)
            {
                sugarCollected();
            }

            //quand sucre petit, scale se rapproche de 0 automatiquement
            transform.localScale -= (transform.localScale * 99/100) * Time.deltaTime;

            Vector3 dir = blowerEntry.transform.position - transform.position;
            transform.Translate(dir.normalized * Time.deltaTime * 0.5f , Space.World);
            //transform.position = Vector3.MoveTowards(transform.position, vacuumEntry.transform.position , 2*Time.deltaTime);

            if (transform.localScale.x <= 0.01f)
            {
                
                sugarCollected();
            }
        }
        else if (transform.localScale.x <= 0.05f)
        {
            isDisappearing = true;

            GetComponent<Collider>().isTrigger = true;//pour eviter les collisions avec l'aspirateur
            //Destroy(gameObject);
        }
               
    }

	void onCollisionEnter(Collider col)
	{
		if (col.gameObject.tag == "CandyMachine")
		{
			Debug.Log("Collision avec la machine");
		}
	}

    void sugarCollected()
    {
        Destroy(gameObject);
		SugarGenerator.sugarCounter--;
    }
}

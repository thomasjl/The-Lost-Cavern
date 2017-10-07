using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour {

    public float speedWheel;
    public bool isMovingForward;
    public bool isMovingBackward;

    public GameObject CommandControlPrefab;


    private Vector3 vecRot;

    public GameObject[] listOfCommandControl;


    void Start()
    {
        isMovingForward = true;
        isMovingBackward = false;
        vecRot = transform.eulerAngles;

        listOfCommandControl = GameObject.FindGameObjectsWithTag("CommandControl");
    }

    void Update ()
    {
        if (Input.GetKeyDown("left"))
        {
            isMovingBackward = true;
            isMovingForward = false;
            foreach (GameObject commandControl in listOfCommandControl)
            {
                commandControl.GetComponent<CommandControl>().setLeft();
            }

        }
        else if (Input.GetKeyDown("right"))
        {
            isMovingBackward = false;
            isMovingForward = true;

            foreach (GameObject commandControl in listOfCommandControl)
            {
                commandControl.GetComponent<CommandControl>().setRight();
            }

           
        }
        else if (Input.GetKeyDown("down"))
        {
            isMovingBackward = false;
            isMovingForward = false;

            foreach (GameObject commandControl in listOfCommandControl)
            {
                commandControl.GetComponent<CommandControl>().setMid();
            }

        }

    }


	// Update is called once per frame
	void LateUpdate () {

        if (isMovingForward)
        {
            vecRot.x += speedWheel;                
            transform.localEulerAngles = vecRot;
        }
        else if (isMovingBackward)
        {
            vecRot.x -= speedWheel;                
            transform.localEulerAngles = vecRot;
        }

		
	}
}

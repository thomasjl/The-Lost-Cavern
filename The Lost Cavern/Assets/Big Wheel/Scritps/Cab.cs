using UnityEngine;

public class Cab : MonoBehaviour {  

    private GameObject axe;
    private Quaternion startRotation;



    void Start ()
    {
        //axe = GameObject.FindGameObjectWithTag("Axe");
        //startRotAxe = axe.transform.rotation.x;
        startRotation = transform.rotation;       
    }


    void LateUpdate()
    {
        //to disable cabs rotation
        transform.rotation = startRotation;


       
    }
}

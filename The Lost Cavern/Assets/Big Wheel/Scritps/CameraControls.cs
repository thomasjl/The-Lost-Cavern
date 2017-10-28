using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour {

   // public float mouseSensitivity = 100.0f;
   // public float clampAngle = 80.0f;

   // private float rotY = 0.0f; // rotation around the up/y axis
    //private float rotX = 0.0f; // rotation around the right/x axis

    public float normalFieldOfView;
    public float zoomFieldOfView;

    private Camera cam;
    public bool isZooming;

    //private LineRenderer line;

    void Start ()
    {
       /*
        Vector3 rot = transform.localRotation.eulerAngles;
        rotY = rot.y;
        rotX = rot.x;
        */

        //cam = GetComponent<Camera>();
        cam = GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().m_Camera;
        isZooming = false;

        }

    void Update ()
    {
        /*
        //rotation
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = -Input.GetAxis("Mouse Y");

        rotY += mouseX * mouseSensitivity * Time.deltaTime;
        rotX += mouseY * mouseSensitivity * Time.deltaTime;

        rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);

        Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
        transform.rotation = localRotation;

        */
        if (Input.GetMouseButton(0))
        {
            Debug.Log("mouse button is done");
            isZooming = true;

        }
       
        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("mouse no longueur clicking");
            isZooming = false;
        }

        if (isZooming)
        {
            cam.fieldOfView = zoomFieldOfView;
        }
        else
        {
            cam.fieldOfView = normalFieldOfView;
        }
                
               
    }




}

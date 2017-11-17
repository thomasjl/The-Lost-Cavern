using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReelMovement : MonoBehaviour {

    public GameObject partoToRotate;
    public GameObject ballVisualization;
    public GameObject origin;
    public GameObject plane;
    public GameObject partToRotate;

    private float oldAngle;
    private float angleReference;

    private GameObject gameManager;
    private GameObject player;

    private Vector3 poigneeReference;

    void Start()
    {
        oldAngle = 0;
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        player = GameObject.FindGameObjectWithTag("Player");

        poigneeReference = partToRotate.transform.eulerAngles;
    }


    void Update()
    {
        // !! Ne pas deplacer la camera en meme temps ! (lorsque controle clavier)
        if (!gameManager.GetComponent<GameManager>().useVive)
        {
            player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().m_MouseLook.XSensitivity = 0;
            player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().m_MouseLook.YSensitivity = 0;
        }


        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");

        ballVisualization.transform.localPosition = new Vector3(ballVisualization.transform.localPosition.x, 0, ballVisualization.transform.localPosition.z); 



        if (x != 0 || y != 0)
        {
            ballVisualization.transform.localPosition += new Vector3(x, 0, y);
             
        }
        //Debug.Log("x : " + x + " y : " + y);       

        if (isInGoodArea())
        {
            //Debug.Log("good area ( " + ballVisualization.transform.localPosition.x + " " + ballVisualization.transform.localPosition.z);
            plane.GetComponent<MeshRenderer>().material.color = Color.white;
            //angleReference = 

            //origin regarde la balle. rotation en z est enregistre.
            origin.transform.right = ballVisualization.transform.position - origin.transform.position;
            //origin.transform.LookAt(ballVisualization.transform);

            // ERREUR 
            // rotation du moulinet
            //partToRotate.transform.localEulerAngles = origin.transform.localEulerAngles;

            Quaternion rotationtoDo = Quaternion.Euler(origin.transform.localEulerAngles.y, 0, 0);

            partToRotate.transform.rotation = rotationtoDo;

            //partToRotate.transform.eulerAngles = new Vector3(origin.transform.localEulerAngles.y, poigneeReference.y , poigneeReference.z );


            //oldAngle = oldAngle;

        }
        else
        {           
            //Debug.Log("not good area"  + ballVisualization.transform.localPosition.x + " " + ballVisualization.transform.localPosition.z);
            plane.GetComponent<MeshRenderer>().material.color  = Color.red;
        }

    }

    bool isInGoodArea()
    {        

        float distanceToOrigin = Vector3.Distance(ballVisualization.transform.localPosition, origin.transform.localPosition);
        Debug.Log("distance :" + distanceToOrigin);

        if (distanceToOrigin >= 3.5f || distanceToOrigin <= 0.2f)
        {
            return false;
        }
        else
        {
            return true;
        }             
      
    }
   
}

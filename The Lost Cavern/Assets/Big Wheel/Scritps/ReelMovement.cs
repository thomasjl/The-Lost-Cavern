using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;
using UnityEngine.UI;

public class ReelMovement : MonoBehaviour {

    public GameObject partoToRotate;
    public GameObject ballVisualization;
    public GameObject origin;
    public GameObject plane;
    public GameObject partToRotate;
    public Text scoreText;

    private float oldAngle;
    private float angleReference;

    private GameObject gameManager;
    private GameObject player;

    //private Vector3 poigneeReference;

    private float oldXVive;
    private float oldYVive;
     

    private float valueToReach;   

    private int score;

    public GameObject gooseHooked;
    public float speedHook;
    public int gooseCatched;

    void Start()
    {
        oldAngle = 0;
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        player = GameObject.FindGameObjectWithTag("Player");

        //poigneeReference = partToRotate.transform.eulerAngles;

        //desactive la sensibilite de la camera (cad bloque la rotation de la camera)
        player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().m_MouseLook.XSensitivity = 0;
        player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().m_MouseLook.YSensitivity = 0;

        //origin.transform.eulerAngles = new Vector3(169, 0, origin.transform.eulerAngles.z);

        if (gameManager.GetComponent<GameManager>().useVive)
        {
            Vector3 rightHand = InputTracking.GetLocalPosition(VRNode.RightHand);
            oldXVive = rightHand.z;
            oldYVive = rightHand.y;

        }

        valueToReach = 0; //atteint des le debut   
        score = 0;       
        gooseCatched = 0;
    }


    void Update()
    {
        //desactive la rotation de la camera
        player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().m_MouseLook.XSensitivity = 0;
        player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().m_MouseLook.YSensitivity = 0;

        scoreText.text= "Score" + score;

        //partToRotate.transform.localEulerAngles = new Vector3(partToRotate.transform.eulerAngles.x, 0, 0);

        float x, y;

        // !! Ne pas deplacer la camera en meme temps ! (lorsque controle clavier)
        if (!gameManager.GetComponent<GameManager>().useVive)
        {
            

            x = Input.GetAxis("Mouse X");
            y = Input.GetAxis("Mouse Y");

        }
        else
        {

            Vector3 rightHand = InputTracking.GetLocalPosition(VRNode.RightHand);
            Debug.Log(rightHand.x + " " + rightHand.y + " " + rightHand.z);

            //z en face, y vers le haut, x a droite
            x = rightHand.z - oldXVive;
            y = rightHand.y - oldYVive;

            oldXVive = rightHand.z;
            oldYVive = rightHand.y;

        }


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
           
            float oldRot = origin.transform.localEulerAngles.y;

            //origin regarde la balle. rotation en z est enregistre.
            //origin.transform.right = ballVisualization.transform.position - origin.transform.position;
            origin.transform.right = ballVisualization.transform.localPosition - origin.transform.localPosition;

            origin.transform.localEulerAngles = new Vector3(0, origin.transform.localEulerAngles.y, 0); 
                    

            float YOrigin = origin.transform.localEulerAngles.y;      


            partToRotate.transform.localEulerAngles = new Vector3(YOrigin, 0, 0);

            //Debug.Log("rotation right axe origin : " + YOrigin);

            //Debug.Log(oldRot + " " + YOrigin);

            float diffRot = YOrigin - oldRot;

            //diffRot doit etre >0 en dehors d'une cabine
            if (diffRot < 0)
            {
                //Debug.Log("bon sens");
                score++;

                if (gooseHooked != null)
                {
                    //goose se rapproche du joueur
                    Vector3 dir = transform.position - gooseHooked.transform.position;
                    gooseHooked.transform.Translate(dir.normalized * Time.deltaTime * speedHook, Space.World);
                }
               
            }
            else
            {
                //Debug.Log("mauvaise sens");
            }
           

            ////////////////////////////////////////*******
            /// 
            ///
            /*



            if (valueToReach == 0)
            {
                
                valueToReach = partToRotate.transform.localEulerAngles.x + (10 - partToRotate.transform.localEulerAngles.x % 10);
                Debug.Log("value to reach : " + valueToReach);
            }


            Debug.Log("valeur courante : " + partToRotate.transform.localEulerAngles.x);
            if (partToRotate.transform.localEulerAngles.x >= valueToReach)
            {
                if (valueToReach == 350)
                {
                    valueToReach = 10;
                }
                else
                {
                    valueToReach += 10; 
                }

                Debug.Log("good use of fishrobb ");
                score++;

            }

            //////////////////*****
            /// 
            /// 
            /// */




            /// 
            /// 
            /// /////////////
            /*

            float oldPartToRotateRot = partToRotate.transform.localEulerAngles.x;

            //set new rot (ne pas se fier a ce qui est indique dans l'inspector)
           

            float diffRot = partToRotate.transform.localEulerAngles.x - oldPartToRotateRot;

            Debug.Log("old ( " + oldPartToRotateRot + " ) new ( " + partToRotate.transform.localEulerAngles.x + " ) ");
                
            if (diffRot > 0)
            {
                Debug.Log("diff positive ");

            }
            else if (diffRot < 0)
            {
                Debug.Log("diff negative" );
            }
            */

           /*
            float YOrigin = origin.transform.localEulerAngles.y;

            Debug.Log("yOrigin : " + YOrigin);

            float convertAngle;

            if (YOrigin < 0)
            {
                convertAngle = 180 + (180 - YOrigin);
            }
            else
            {
                convertAngle = YOrigin;
            }

            Debug.Log("convertAngle : " + convertAngle);

            float oldConvertPartToRotateAngle = partToRotate.transform.localEulerAngles.x;

            partToRotate.transform.localEulerAngles = new Vector3(convertAngle, 0, 0);

            float diffAngle = convertAngle - oldConvertPartToRotateAngle;


            if (diffAngle > 0)
            {
                Debug.Log("diff positive ");

            }
            else
            {
                Debug.Log("diff negative" );
            }

*/
            //////////////////////////////
           




            /* 
            partToRotate.transform.localEulerAngles = new Vector3(origin.transform.localEulerAngles.y, 0, 0);

            float convertAngle;

            if (partToRotate.transform.localEulerAngles.x < 0)
            {
                convertAngle = 180 + (180 - partToRotate.transform.localEulerAngles.x);
            }
            else
            {
                convertAngle = partToRotate.transform.localEulerAngles.x;
            }

            float diffAngle = convertAngle - oldConvertPartToRotateAngle;
           

            if (diffAngle > 0)
            {
                Debug.Log("diff positive ");

            }
            else
            {
                Debug.Log("diff negative" );
            }
            */

           
           
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
        //Debug.Log("distance :" + distanceToOrigin);

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

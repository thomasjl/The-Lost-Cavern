﻿using UnityEngine;
using System.Collections;

public class Fly : MonoBehaviour {


   //vole entre altMin et altMax

    //peut choisir entre : descendre(0), stagner(1), monter(2)

    //si a atteint limite en bas, forcer de remonter
    //si a atteint limite du haut, forcer de redescendre


    public float speedRotation;

    public float speedMove;

    private GameObject rotationPoint;
    private GameObject yMax;
    private GameObject yMin;
    private Rigidbody rb;
    private bool canMove;

    private bool hooked;
 
    private float timer;
    private bool isVisible;
    private GameObject player;

    private GameObject fishingRod;

    void Start()
    {          
        rb = GetComponent<Rigidbody>();
        rotationPoint = GameObject.FindGameObjectWithTag("RotationPoint");
        player = GameObject.FindGameObjectWithTag("Player");
        yMin = GameObject.FindGameObjectWithTag("yMin");
        yMax = GameObject.FindGameObjectWithTag("yMax");
        canMove = true;

        //fishingRod = GameObject.FindGameObjectWithTag("FishingRod");

        timer = 0f;
        isVisible = false;
        hooked = false;

    }

    void OnBecameVisible()
    {
        // attention, fonction egalement appelle, lorsque gameObject visible sur l'ecran "Scene"

        //fonction appelee lorsque le canard apparait sur l'ecran ( a chaque frame)

        //demarrer compteur. Si fixe pdt 4s, canard est detruit
      if (!isVisible)
        {
            //timer = 0f;
            isVisible = true;
        }
       
        //Debug.Log(gameObject.name + " on screen");

    }

    void OnBecameInvisible()
    {
        isVisible = false;
        timer = 0;
        //Debug.Log(gameObject.name + " out of screen");
    }
        

    void Update()
    {      
        //calcul de la distance entre le canard et le joueur. Si la distance est inferieur a 7, le canard est attrape
        float distanceBtGooseAndPlayer = Vector3.Distance(transform.position, player.transform.position);

        if (distanceBtGooseAndPlayer <= 10f)
        {
            Debug.Log("goose captured !");
            player.GetComponent<CameraControls>().referenceScriptFishingRob.GetComponent<ReelMovement>().gooseCatched++;
            player.GetComponent<CameraControls>().referenceFishingRob.SetActive(false);
            player.GetComponent<CameraControls>().hookSth = false;
            player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().m_MouseLook.XSensitivity = 2;
            player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().m_MouseLook.YSensitivity = 2;
            Destroy(gameObject);
        }

        if (hooked)
        {
            return;
        }

        //Debug.Log("timer : " + timer);
        if (timer >= 4.0f)
        {            
            player.GetComponent<CameraControls>().referenceFishingRob.SetActive(true);
            player.GetComponent<CameraControls>().referenceScriptFishingRob.GetComponent<ReelMovement>().gooseHooked = gameObject;
            player.GetComponent<CameraControls>().hookSth = true;
            hooked = true;
            //Destroy(gameObject);
        }

        if (isVisible && player.GetComponent<CameraControls>().isZooming)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0f;
        }
            

        transform.RotateAround(rotationPoint.transform.position, Vector3.up, speedRotation * Time.deltaTime);

        if (yMax.transform.position.y - transform.position.y <= 0.1f)
        {
            rb.AddForce(-transform.up * speedMove);
            canMove = false;
        }
        else if (transform.position.y - yMin.transform.position.y  <= 0.1f)
        {
            rb.AddForce(transform.up * speedMove);
            canMove = false;
        }



        if (canMove)
        {
            float moveDuration = Random.Range(2f, 4f);
            int movePosition = Random.Range(0, 3);
            Debug.Log("position : " + movePosition);
            if (movePosition == 0)
            {
                //go down
                StartCoroutine(goDown(moveDuration));
                //goDown(moveDuration);
            }
            else if(movePosition == 1)
            {
                //keep position
                StartCoroutine(keepPosition(moveDuration));
                //keepPosition(moveDuration);

            }
            else if(movePosition == 2)
            {
                //go up  

                StartCoroutine(goUp(moveDuration));
                //goUp(moveDuration);
            }

            canMove = false;

        }

    }

    IEnumerator goDown(float duration)
    { 
        rb.AddForce(-transform.up * speedMove);
        yield return new WaitForSeconds(duration);
        canMove = true;
    }

    IEnumerator keepPosition(float duration)
    {
        yield return new WaitForSeconds(duration);
        canMove = true;
    }

    IEnumerator goUp(float duration)
    {
        rb.AddForce(transform.up * speedMove);
        yield return new WaitForSeconds(duration);
        canMove = true;
    }

       

	
}

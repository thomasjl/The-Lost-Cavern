using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;
using UnityEngine.UI;

public class DuckGameManager : MonoBehaviour {

    public GameObject launchDucks;
    public Text launcheGameText;
    public GameObject duckRewardPrefab;

    private bool canBeginGame;
    private GameObject player;

    private GameObject gameManager;   

    private bool inGame;


    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        canBeginGame = false;
        player = GameObject.FindGameObjectWithTag("Player");
        launcheGameText.enabled = false;
        inGame = false;
       



    }

    void Update()
    {
        if (canBeginGame)
        {
            launcheGameText.enabled = true;
        }

        if (canBeginGame && actionButtonDetected())
        {
            Debug.Log("game begins");
            canBeginGame = false;
            launcheGameText.enabled = false;
            inGame = true;


            launchDucks.GetComponent<GenerateDucks>().enabled = true;
            player.GetComponent<CameraControls>().enabled = true;

        }     

        if (inGame && player.GetComponent<CameraControls>().referenceScriptFishingRob.GetComponent<ReelMovement>().gooseCatched >=5)
        {
            player.GetComponent<CameraControls>().enabled = false;

            GameObject duckReward = Instantiate( duckRewardPrefab , player.transform.GetChild(0).position, Quaternion.identity);
            duckReward.transform.parent = null;
            duckReward.transform.position = player.transform.position + new Vector3(0, -0.5f, 2f);
            duckReward.transform.eulerAngles = new Vector3(0, -90, 0);

            Debug.Log("end of game ! ");
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {            
            Debug.Log("can play game");
            canBeginGame = true;
        }


    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            canBeginGame = false;
        }

    }

    bool actionButtonDetected()
    {
        if (gameManager.GetComponent<GameManager>().useVive)
        {
            if (UnityEngine.Input.GetButtonDown("2"))
            {                
                return true;
            }

        }
        else
        {
            if (Input.GetKeyDown("e"))
            {
                return true;
            }
        }

        return false;
    }
}

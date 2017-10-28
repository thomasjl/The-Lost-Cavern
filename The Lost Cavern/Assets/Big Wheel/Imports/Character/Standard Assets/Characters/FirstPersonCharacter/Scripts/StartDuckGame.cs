using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDuckGame : MonoBehaviour {

    public GameObject launchDucks;

    private bool canBeginGame;
    private GameObject player;

    void Start()
    {
        canBeginGame = false;
        player = GameObject.FindGameObjectWithTag("Player");

    }

    void Update()
    {
        if (canBeginGame && Input.GetKeyDown("e"))
        {
            
            launchDucks.GetComponent<GenerateDucks>().enabled = true;
            player.GetComponent<CameraControls>().enabled = true;
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
}

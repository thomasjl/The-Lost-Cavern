using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookPanelToExit : MonoBehaviour {

    public GameObject spawnAreaExit;

    private bool panelVisible;
    private GameObject player;
    private bool canBeDetected;

    void Start()
    {
        panelVisible = false;
        canBeDetected = false;

        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (panelVisible && canBeDetected && Input.GetMouseButtonDown(1))
        {
            Debug.Log("see panel, and click detected");

            //met le boolean inside a zero, de la cabine (grand parent du player)
            GameObject cab = player.transform.parent.gameObject.transform.parent.gameObject;
            cab.GetComponent<Cab>().inside = false;

            // on eleve le player de la hierarchie de la cabine
            player.transform.parent = null;

            player.transform.position = spawnAreaExit.transform.position;
            player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().m_WalkSpeed = player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().startWalkSpeed;

        }
    }

    void OnBecameVisible()
    {
        panelVisible = true;
    }

    void OnBecameInvisible()
    {
        panelVisible = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            canBeDetected = true;
        }


    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            canBeDetected = false;
        }
        
    }

}

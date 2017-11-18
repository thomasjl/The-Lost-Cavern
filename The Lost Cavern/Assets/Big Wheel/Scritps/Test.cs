using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

    GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
		
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("clique gauche");
           
            //mettre rotation a zero (fps controller)
            //GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().m_MouseLook.m_CameraTargetRot = Quaternion.identity;
            //GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().m_MouseLook.m_CharacterTargetRot = Quaternion.identity;

            player.GetComponent<CameraControls>().referenceFishingRob.SetActive(true);

        }

	}
}

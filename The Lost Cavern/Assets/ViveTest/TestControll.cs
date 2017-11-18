using
System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;

public class TestControll : MonoBehaviour {

    void Update()
    {
        Vector3 leftHand = InputTracking.GetLocalPosition(VRNode.LeftHand);;
        Debug.Log(leftHand.x + " " + leftHand.y + " " + leftHand.z);
    }

  

}

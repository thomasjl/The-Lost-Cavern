using UnityEngine;

public class Cabs : MonoBehaviour {

    public GameObject CamPrefab;
    public GameObject CommandControlPrefab;


    void Start ()
    {
        

        // for each cab; instantiate a disabled camera + command control
        //GameObject[] listOfCabs = GetComponentsInChildren<GameObject>();
        foreach (Transform cab in transform)
        {
            Instantiate(CamPrefab, cab);
            Instantiate(CommandControlPrefab, cab);


        }
    }

}

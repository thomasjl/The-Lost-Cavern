using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateDucks : MonoBehaviour {

    public GameObject prefabDuck;
    private GameObject yMax;
    private GameObject xMax;
    private GameObject zMax;

    private GameObject yMin;
    private GameObject xMin;
    private GameObject zMin;

   

    void Start ()
    {
        yMax = GameObject.FindGameObjectWithTag("yMax");
        xMax = GameObject.FindGameObjectWithTag("xMax");
        zMax = GameObject.FindGameObjectWithTag("zMax");


        yMin = GameObject.FindGameObjectWithTag("yMin");
        xMin = GameObject.FindGameObjectWithTag("xMin");
        zMin = GameObject.FindGameObjectWithTag("zMin");   


        StartCoroutine(createDucks());


        //plusieurs vagues, avec des vitesses de rotation et vertical de plus en plus rapide
    }


    IEnumerator createDucks ()
    {

        int xSign = Random.Range(0, 2) * 2 - 1;
        int zSign = Random.Range(0, 2) * 2 - 1;

        for (int i=0; i < 5; i++)
        {
            Vector3 initPos = new Vector3(xSign*Random.Range(xMin.transform.position.x, xMax.transform.position.x), Random.Range(yMin.transform.position.y, yMax.transform.position.y), zSign * Random.Range(zMin.transform.position.z, zMax.transform.position.z));

            yield return new WaitForSeconds(2f);

            Debug.Log("prefabduck : " + prefabDuck);
            Instantiate(prefabDuck, initPos, Quaternion.identity);

        }

    }
}

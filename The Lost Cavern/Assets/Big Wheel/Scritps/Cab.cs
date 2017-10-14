using UnityEngine;

public class Cab : MonoBehaviour {  

    public Material transparent;
    public Material originalMaterial;

    private GameObject axe;
    private Quaternion startRotation;

    public float range;
    private Renderer rend;

    public Material[] materials;
    public Material[] newMaterials;

    private bool canAccess;
    private GameObject player;





    void Start ()
    {     
        startRotation = transform.rotation;      
        rend = GetComponent<Renderer>();

        materials = GetComponent<MeshRenderer>().materials;
        newMaterials = materials;
        newMaterials[1] = transparent;
        newMaterials[2] = transparent;

        materials = GetComponent<MeshRenderer>().materials;;
        canAccess = false;

        player = GameObject.FindGameObjectWithTag("Player");
        axe = GameObject.FindGameObjectWithTag("Axe");
    }

    void Update ()
    {
        if (canAccess && Input.GetMouseButtonDown(1))
        {
            Debug.Log("can enter");
            player.SetActive(false);

            transform.GetChild(0).gameObject.SetActive(true);
            //GetComponentInChildren<Camera>().gameObject.SetActive(true);
            GetComponent<MeshRenderer>().materials = materials;
            canAccess = false;
            axe.GetComponent<Axe>().canControl = true;
        }
    }

    void LateUpdate()
    {
        //to disable cabs rotation
        transform.rotation = startRotation;


       
    }

    void OnTriggerEnter (Collider other)
    {
        if (other.tag != "Cab")
        {            
            //rend.materials[1] = transparent;
            GetComponent<MeshRenderer>().materials = newMaterials;

            canAccess = true;
        }      

    }

    void OnTriggerExit (Collider other)
    {
        if (other.tag != "Cab")
        {
            GetComponent<MeshRenderer>().materials = materials;
            canAccess = false;
        }
    }

    void OnDrawGizmosSelected ()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere (transform.position, range);
    }
}

using UnityEngine;

public class Cab : MonoBehaviour {  

    public Material transparent;
    public Material originalMaterial;

    public GameObject CommandControlPrefab;

    private GameObject axe;
    private Quaternion startRotation;

    public float range;
    private Renderer rend;

    public Material[] materials;
    public Material[] newMaterials;

    private bool canAccess;
    private GameObject player;

    public bool inside;
    private GameObject goodRotationForPlayer;

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

        goodRotationForPlayer = new GameObject();
        goodRotationForPlayer.transform.position = transform.position;
        Vector3 tempRotation = transform.localEulerAngles + new Vector3(-130f, -90f, 180f);
        goodRotationForPlayer.transform.localEulerAngles = tempRotation;
        goodRotationForPlayer.transform.parent = transform;
        goodRotationForPlayer.name = "PlayerRotation";
     
        GameObject commandControl = Instantiate(CommandControlPrefab, transform.position + new Vector3(0,0,-6f), Quaternion.identity);
       
        commandControl.transform.localEulerAngles = new Vector3(0f, -90f, 0f);
        commandControl.transform.parent = transform;

        inside = false;
    }

    void Update ()
    {
        if (inside)
        {
            goodRotationForPlayer.transform.position = transform.position;
            player.transform.position = goodRotationForPlayer.transform.position;
            canAccess = false;
            //Debug.Log("player rotation in cab : " + player.transform.localEulerAngles.x + " " + player.transform.localEulerAngles.y + " " + player.transform.localEulerAngles.z);
        }

        if (canAccess && Input.GetMouseButtonDown(1))
        {
            Debug.Log("enter in "+ gameObject.name);

            //insere le gameobject dans la hierarchie, pour que le player voit correctement
           

            inside = true;
            //change la position du player, pour le mettre dans la cabine
            player.transform.position = goodRotationForPlayer.transform.position;
            //instantie en tant qu'enfant, pour que le personnage suive la cabine
            player.transform.parent = goodRotationForPlayer.transform;

            //l'immobilise (walk+run à 0)
            player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().m_WalkSpeed = 0;
            player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().m_RunSpeed = 0;


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

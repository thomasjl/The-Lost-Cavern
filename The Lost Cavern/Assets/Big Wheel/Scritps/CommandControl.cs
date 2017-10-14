using UnityEngine;

public class CommandControl : MonoBehaviour {

    public GameObject command;//0 22.31 
     
    private string position;
    private Vector3 left;
    private Vector3 mid;
    private Vector3 right;
    private float timer =0f;

    private Vector3 currentRot;
    private float rotateTime = 0.5f;

    private string currentPosition;
    private GameObject axe;

    void Start ()
    {
        left = new Vector3(-23.31f, 0, 0);
        mid = new Vector3(0, 0, 0);
        right = new Vector3(23.31f, 0, 0);

        axe = GameObject.FindGameObjectWithTag("Axe");
        //axe.GetComponent<Axe>().canControl = true;
         
        currentRot = command.transform.localEulerAngles;

        Debug.Log("relative position : " + transform.localPosition);
        position = "right";
        currentPosition = "right";
    }

    public void setLeft ()
    {
        if (position == "left")
        {
            return;
        }

        if (position == "mid")
        {
            currentRot += left;
        }
        else
        {
            //right
            currentRot += left;
            currentRot += left;
        }
        Debug.Log("position " + position);
        position = "left";
        command.transform.localEulerAngles = currentRot;
    }

    public  void setMid()
    {
        if (position == "mid")
        {
            return;
        }

        if (position == "left")
        {
            currentRot += right;
        }
        else if (position == "right")
        {
            currentRot += left;
        }

        position = "mid";
        command.transform.localEulerAngles = currentRot;
    }

    public void setRight()
    {
        if (position == "right")
        {
            return;
        }

        if (position == "mid")
        {
            currentRot += right;
        }
        else
        {
            currentRot += right;
            currentRot += right;
        }
        position = "right";

        command.transform.localEulerAngles = currentRot;
    }
      
	
}

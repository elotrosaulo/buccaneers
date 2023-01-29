using UnityEngine;

public class MagicDoor : MonoBehaviour
{
    public GameObject doorGO;

    void Start()
    {
        KeyPannel.OnKeyFound -= HideTheDoor;
        KeyPannel.OnKeyFound += HideTheDoor;
    }

    private void HideTheDoor()
    { 
        // HIDE THE DOOR!
        doorGO.transform.position = new Vector3(0,0,5);
        Debug.Log("hide the door");
    }
}

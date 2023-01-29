using UnityEngine;

public class MagicDoor : MonoBehaviour
{
    public GameObject doorGO;

    void Start()
    {
        doorGO.SetActive(true);
        KeyPannel.OnKeyFound -= HideTheDoor;
        KeyPannel.OnKeyFound += HideTheDoor;
    }

    private void HideTheDoor()
    { 
        // HIDE THE DOOR!
        doorGO.SetActive(false);
    }
}

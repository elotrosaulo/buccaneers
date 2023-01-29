using UnityEngine;

public class DoorGuard : MonoBehaviour
{
    public Dialogue dialogue;

    private void OnTriggerEnter(Collider other)
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue, true, "Try Your Luck", DialogueManager.ActionType.OpenMiniGame);
    }
}

using UnityEngine;

public class DoorGuard : MonoBehaviour
{
    public Dialogue dialogue;
    public Canvas Ui;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Ui.enabled = false ; 
            
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue, true, "Try Your Luck", DialogueManager.ActionType.OpenMiniGame);
        }
    }
    private void OnTriggerExit(Collider other){
        if (other.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<DialogueManager>().EndDialogue();
            Ui.enabled = true ; 
        }
    }
}

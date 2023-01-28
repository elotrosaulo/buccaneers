using UnityEngine;

public class KeyPannel : MonoBehaviour
{
    public Transform parent;
    public Transform initPosition;
    public Key keyPrefab;
    public int numberOfKeys;
    public int rows;
    public int columns;
    public float xSpace;
    public float ySpace;
    public bool isGameOver;

    [Header("Dialogues")]
    public Dialogue winnerDialogue;
    public string winButtonText;
    public Dialogue looserDialogue;
    public string looseButtonText;

    private int openDoorKey;
    public int OpenDoorKey => openDoorKey;

    public void Initialize()
    {
        DialogueManager.OnDialogEnded -= HidePannel;
        DialogueManager.OnDialogEnded += HidePannel;

        openDoorKey = Random.Range(1, numberOfKeys + 1);
        isGameOver = false;

        if (!parent.gameObject.activeSelf)
            ShowPannel(true);

        for (int i = 0; i < numberOfKeys; i++)
        {
            var key = Instantiate(keyPrefab, new Vector3( initPosition.position.x + xSpace * (i % columns), 
                                                initPosition.position.y + (-ySpace * (i / columns))), 
                        Quaternion.identity,
                        parent);

            key.SetText(i+1, this);
        }
    }

    public void HidePannel()
    {
        if(isGameOver)
            ShowPannel(false);
    }

    public void ShowPannel(bool value)
    {
        parent.gameObject.SetActive(value);
    }

    public void Reset()
    {
        for (int i = parent.childCount - 1; i >= 0; i--)
        { 
            Destroy(parent.GetChild(i).gameObject);
        }

        Initialize();
    }

    public void WinChallenge()
    {
        Debug.Log("YOU WIN!!! Do something!. Open the door??");
    }

    public static void CheckKey(Key key, KeyPannel pannel)
    {
        var openDoorKey = pannel.OpenDoorKey;
        if (key.ID == openDoorKey)
        {
            Debug.Log("YOU HAVE THE RIGHT KEY!");
            key.ChangeColor(Color.green);
        }
        else
        {
            Debug.Log($"Wrong key... the right one is {openDoorKey}");
            key.ChangeColor(Color.red);
        }

        key.pannel.SendResultDialogue(key.ID, pannel);
    }

    private void SendResultDialogue(int keyID, KeyPannel pannel)
    {
        if (keyID == pannel.OpenDoorKey)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(winnerDialogue, true, winButtonText, DialogueManager.ActionType.WinChallenge);
        }
        else
        {
            FindObjectOfType<DialogueManager>().StartDialogue(looserDialogue, true, looseButtonText, DialogueManager.ActionType.ResetKeyPannel, pannel.openDoorKey.ToString());
        }

        isGameOver = true;
    }
}

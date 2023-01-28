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

    private int openDoorKey;
    public int OpenDoorKey => openDoorKey;

    void Start()
    {
        Initialize();
        openDoorKey = Random.Range(1, numberOfKeys+1);
    }

    private void Initialize()
    {
        for (int i = 0; i < numberOfKeys; i++)
        {
            var key = Instantiate(keyPrefab, new Vector3( initPosition.position.x + xSpace * (i % columns), 
                                                initPosition.position.y + (-ySpace * (i / columns))), 
                        Quaternion.identity,
                        parent);

            key.SetText(i+1, this);
        }
    }

    public static void CheckKey(int keyID, int openDoorKey)
    {
        if (keyID == openDoorKey)
        {
            Debug.Log("YOU HAVE THE RIGHT KEY!");
        }
        else
        {
            Debug.Log($"Wrong key... the right one is {openDoorKey}");
        }
    }
}

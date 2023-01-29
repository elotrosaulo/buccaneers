using UnityEngine;

public class VictoryPoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("We are passing through the door. We WIN!!");
        GameManager.instance.Victory();
    }
}

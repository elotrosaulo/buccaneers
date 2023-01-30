using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class RobotAnimVictory : MonoBehaviour
{
    public Sprite[] frames;
    public float framesPerSecond = 10;
    private Image image;

    private void Start()
    {
        image = GetComponent<Image>();
    }

    private void Update()
    {
        Debug.Log("gif");
        int index = (int)(Time.time * framesPerSecond) % frames.Length;
        image.sprite = frames[index];
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI2DButton : MonoBehaviour
{
    public Sprite regular;
    public Sprite mouseOver;
    public Sprite mouseClicked;
    public TextMeshPro buttonText;
    public Key key;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        Debug.Log($"Hi. I'm the key {key.ID}");
        KeyPannel.CheckKey(key.ID, key.pannel.OpenDoorKey);
    }

    private void OnMouseEnter()
    {

    }

    private void OnMouseExit()
    {

    }

    private void OnMouseUpAsButton()
    {

    }
}

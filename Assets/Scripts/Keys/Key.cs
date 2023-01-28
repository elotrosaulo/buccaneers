using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Key : MonoBehaviour
{
    public Text text;
    public int ID;
    public KeyPannel pannel;

    public void SetText(int id, KeyPannel pannel)
    {
        text.text = id.ToString();
        ID = id;
        this.pannel = pannel;
    }

    public int GetID()
    {
        return ID;
    }

    public void ChangeColor(Color color)
    { 
        gameObject.GetComponent<SpriteRenderer>().material.color = color;
    }
}

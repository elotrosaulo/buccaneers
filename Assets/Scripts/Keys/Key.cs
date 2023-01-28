using TMPro;
using UnityEngine;

public class Key : MonoBehaviour
{
    public TextMeshPro text;
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

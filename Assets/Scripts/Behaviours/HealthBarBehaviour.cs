using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarBehaviour : MonoBehaviour
{
    public Slider slider;
    public TextMeshProUGUI text;


    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
        text.text = health + "%";
    }
    
    public void SetHealth(int health)
    {
        slider.value = health;
        text.text = health + "%";
    }
}

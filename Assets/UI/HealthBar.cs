using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Text text;
    public Gradient gradient;
    public Image fill;

    // Start is called before the first frame update

    public void setMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
        text.text = health.ToString();

        fill.color = gradient.Evaluate(1f);
    }

    public void setHealth(int health)
    {
        slider.value = health;
        text.text = health.ToString();

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }


}

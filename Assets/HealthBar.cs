using UnityEngine.UI;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void Start()
    {
        fill.color = gradient.Evaluate(slider.value);
    }

    public void SetHealth(float health)
    {
        slider.value = health;
        fill.color = gradient.Evaluate(slider.value);
    }
}

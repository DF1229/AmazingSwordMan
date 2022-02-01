using UnityEngine.UI;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    public void SetHealth(float health)
    {
        slider.value = health;
    }
}

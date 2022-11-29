using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxDash(int dash)
    {
        slider.maxValue = dash;

        slider.value = dash;
    }

    public void SetDash(int dash)
    {
        slider.value = dash;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextSlider : MonoBehaviour
{

    public Text numberText;

    public void SetNumberText(float value)
    {
        numberText.text = value.ToString();
    }
}

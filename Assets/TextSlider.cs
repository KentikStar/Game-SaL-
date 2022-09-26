using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TextSlider : MonoBehaviour
{
    TextMeshProUGUI text;

    [SerializeField]
    Slider slider;

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    public void ChangeText(){
        text.text = Convert.ToString(slider.value);
    }
}

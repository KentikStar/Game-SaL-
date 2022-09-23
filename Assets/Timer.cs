using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI textWatch;
    
    void Start()
    {
        StartCoroutine(TimerSecond(10));
    }

    IEnumerator TimerSecond(int seconds){

        for(int i = seconds; i >= 0; i--){
            yield return new WaitForSeconds(1);
            ChangeTimer(i);
        }
    }

    void ChangeTimer(int seconds){
        int minutes = seconds / 60;
        seconds = seconds % 60;

        string text = $"{TimeRounding(minutes)}:{TimeRounding(seconds)}";

        textWatch.text = text;
    }

    string TimeRounding(int value){
        if(value / 10 < 1)
            return "0"+value;

        return Convert.ToString(value);
    }
}

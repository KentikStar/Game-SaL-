using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI textWatch;

    [SerializeField]
    GameControl gameControl;

    int seconds = 30;

    public void VisibleTimer(string mode)
    {
        if(mode != "Time")
            this.gameObject.SetActive(false);
    }

    public void SaveSeconds(Slider slider){
        seconds = Convert.ToInt32(slider.value);
    }
    
    public void StartTimer(){
        StartCoroutine(TimerSecond(seconds));
    }

    IEnumerator TimerSecond(int seconds){

        for(int i = seconds; i >= 0; i--){
            yield return new WaitForSeconds(1);
            ChangeTimer(i);
        }
        gameControl.EndGame();
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

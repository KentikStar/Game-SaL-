using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameControl : MonoBehaviour
{
    [SerializeField]
    EnemyControl enemyControl;

    [SerializeField]
    TextMeshProUGUI textKills;

    [SerializeField]
    Timer timer;

    [SerializeField]
    UIControl uIControl;

    public float MouseSens{get; set;}

    private int killsCount;
    public int KillsCount {
        get{
         return killsCount;}
        set{
            killsCount = value;
            CheckValueKills();
        }
    }

    private static bool isTimeOver = false;

    public static bool IsTimeOver{get{
        return isTimeOver;        
    }set{
        isTimeOver = value;
    }
    }

    private static bool isPaused = false;

    public static bool IsPaused{get{
        return isPaused;        
    }set{
        isPaused = value;
    }
    }
    private string mode;

    public string Mode{
        get{
            return mode;
        }
        set{
            mode = value;            
        }
    }

    
    public void StartGame(){
        timer.StartTimer();
        uIControl.CloseMenuStart();
        IsTimeOver = false;

    }

    public void EndGame(){
        uIControl.PauseOn();
        isTimeOver = true;  
    }

    public void RestartGame(){
        IsTimeOver = true;
        KillsCount = 0;
        IsTimeOver = false;
        if(Mode == "Time"){
            uIControl.PauseOff();
            uIControl.OpeneMenuStart();
        }
        else{
            timer.StopStopwatch();
            timer.StartStopwatch();
            uIControl.PauseOff();
        }
    }

    void Start()
    {
        LoadSettings();

        if(Mode == "Time")
            uIControl.OpeneMenuStart();
        else
            timer.StartStopwatch();
    }

    private void CheckValueKills(){
        textKills.text = $"Kills: {killsCount}";

        if(killsCount % 25 == 0)
            enemyControl.Reset();

        if(killsCount % 5 == 0)
            enemyControl.StartSpawn();        
    }

    void LoadSettings(){
        Settings settings;
        SaveSerial saveSerial = new SaveSerial();

        saveSerial.LoadGame(out settings);

        MouseSens = settings.MouseSens;
        Mode = settings.Mode;
        Debug.Log("aaaaa"+settings.Mode);
    }
}

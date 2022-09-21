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

    void Start()
    {
        LoadSettings();
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
    }
}

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

    private int killsCount;
    public int KillsCount {
        get{
         return killsCount;}
        set{
        killsCount = value;
        CheckValueKills();
        }
    }

    private void CheckValueKills(){
        textKills.text = $"Kills: {killsCount}";

        if(killsCount % 25 == 0)
            enemyControl.Reset();

        if(killsCount % 5 == 0)
            enemyControl.StartSpawn();        
    }
}

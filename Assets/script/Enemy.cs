using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{   
    [SerializeField]
    GameControl gameControl;
     public bool IsFree {get; set;} = true;
    private void OnDisable()
    {
        if(!GameControl.IsTimeOver)
            gameControl.KillsCount++;
    }
}

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
        gameControl.KillsCount++;
    }
}

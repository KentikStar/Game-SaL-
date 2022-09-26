using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mode : MonoBehaviour
{
    [SerializeField]
    string modeName;

    public string ModeName{get{
        return modeName;
    } set{
        modeName = value;
    }}

    GameMode gameMode;

    void Start()
    {
        gameMode = GetComponentInParent<GameMode>();

        ActiveAnimator();
    }

    void ActiveAnimator(){
        
        Settings settings;
        SaveSerial saveSerial = new SaveSerial();

        saveSerial.LoadGame(out settings);

        if(settings.Mode == ModeName){
            
            Animator animator = GetComponent<Animator>();
            animator.SetBool("Checked",true);
        }
    }



    void OnMouseDown()
    {
        gameMode.ChangeAnimator(this);
    }
}

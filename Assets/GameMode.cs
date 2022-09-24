using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMode : MonoBehaviour
{

    string nameMode;

    public string NameMode{
        get{
            return nameMode;
    }set{
        nameMode = value;

    }}

    [SerializeField]
    Animator animatorActive;

    [SerializeField]
    SettingsContrl settingsContrl;


    void Start()
    {
        NameMode = settingsContrl.ModeStr;
    }


    public void ChangeAnimator(Mode mode){
        Animator animator = mode.GetComponent<Animator>();
        
        animator.SetBool("Checked", true);
        animatorActive.SetBool("Checked", false);

        settingsContrl.ModeStr = mode.ModeName;
        settingsContrl.ChangeSettings();

        animatorActive = animator;
    }


}

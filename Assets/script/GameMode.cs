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
        Debug.Log(NameMode);
        StartAcitveMode();
    }

    private void StartAcitveMode(){
        Mode modeChild;
        for(int i = 0; i < transform.childCount; i++){
            modeChild = transform.GetChild(i).GetComponentInChildren<Mode>();
            if(NameMode == modeChild.ModeName){
                animatorActive = modeChild.GetComponent<Animator>();
                Debug.Log("animator edit");
                
            }
        }
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

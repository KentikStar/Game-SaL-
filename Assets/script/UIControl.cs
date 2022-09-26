using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIControl : MonoBehaviour
{

    [SerializeField]
    Animator animatorPause;

    [SerializeField]
    string sceneName = "MainMenu";

    void Start()
    {
        Cursor.visible = false;
        OpeneMenuStart();
    }


    void Update()
    {
        Paused();
    }

    void Paused(){
        if(Input.GetKeyDown(KeyCode.Escape) && !GameControl.IsTimeOver){
            if(GameControl.IsPaused){
                PauseOff();
            }
            else{
                PauseOn();
            }
        }
    }

    public void ReturnMenu(){
        PauseOff();
        SceneManager.LoadSceneAsync(sceneName);
    }

    public void CloseMenuStart(){
        animatorPause.SetBool("OpenMenuStart",false);
        Time.timeScale = 1;
        GameControl.IsPaused = false;
        Cursor.visible = false;
        GameControl.IsTimeOver = false;
    }

    public void OpeneMenuStart(){
        animatorPause.SetBool("OpenMenuStart",true);
        Time.timeScale = 0;
        GameControl.IsPaused = true;
        Cursor.visible = true;
        GameControl.IsTimeOver = true;
    }

    public void PauseOn(){
        animatorPause.SetBool("OpenMenu",true);
        Time.timeScale = 0;
        GameControl.IsPaused = true;
        Cursor.visible = true;
    }

    public void PauseOff(){
        animatorPause.SetBool("OpenMenu",false);
        Time.timeScale = 1;
        GameControl.IsPaused = false;
        Cursor.visible = false;
    }
}

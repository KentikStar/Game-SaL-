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

        //OpeneMenuStart();
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
        Cursor.visible = true;
        SceneManager.LoadSceneAsync(sceneName);
        GameControl.IsTimeOver = false;
    }

    public void CloseMenuStart(){
        animatorPause.SetBool("OpenMenuStart",false);
        Play();
        GameControl.IsTimeOver = false;
    }

    public void OpeneMenuStart(){
        animatorPause.SetBool("OpenMenuStart",true);
        Pause();
        GameControl.IsTimeOver = true;
    }

    public void PauseOn(){
        animatorPause.SetBool("OpenMenu",true);
        Pause();
    }

    public void PauseOff(){
        animatorPause.SetBool("OpenMenu",false);
        Play();
    }

    private void Pause(){
        Time.timeScale = 0;
        GameControl.IsPaused = true;
        Cursor.visible = true;
    }

    private void Play(){
        Time.timeScale = 1;
        GameControl.IsPaused = false;
        Cursor.visible = false;
    }
}

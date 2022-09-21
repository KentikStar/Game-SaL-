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


    void Update()
    {
        Paused();
    }

    void Paused(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(GameControl.IsPaused){
                PauseOff();
            }
            else{
                PauseOn();
            }
        }
    }

    public void Restart(){
        Debug.Log("LVL RESTART");
    }

    public void ReturnMenu(){
        PauseOff();
        SceneManager.LoadSceneAsync(sceneName);
    }

    void PauseOn(){
        animatorPause.SetBool("OpenMenu",true);
        Time.timeScale = 0;
        GameControl.IsPaused = true;
    }

    void PauseOff(){
        animatorPause.SetBool("OpenMenu",false);
        Time.timeScale = 1;
        GameControl.IsPaused = false;
    }
}

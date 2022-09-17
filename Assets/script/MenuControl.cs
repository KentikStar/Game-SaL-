using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuControl : MonoBehaviour
{
    Animator animatorCamera;

    [SerializeField]
    Animator animatorSettings;

    [SerializeField]
    string sceneName;

    void Start()
    {
        animatorCamera = Camera.main.GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        CurseFocus(true);

    }

 


    void CurseFocus(bool onAnimator)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit raycastHit;

        GameObject target;

        if(Physics.Raycast(ray, out raycastHit))
        {
            target = raycastHit.transform.gameObject;

                if(target.tag == "UI")
                            Select(target);
        }
    }

    void Select(GameObject target){
        UITarget uITarget = target.GetComponent<UITarget>();
            switch(uITarget.Name)
            {
                case "Settings":
                    animatorCamera.SetBool("Settings",true);
                    animatorSettings.SetBool("isOpen",true);
                    break;
                case "Start":
                    animatorCamera.SetBool("Close",true);
                    StartCoroutine(StartGame());
                    break;
                case "Exit":
                    animatorCamera.SetBool("Close",true);
                    StartCoroutine(ExitGame());
                    break;
                
            }
    }

    IEnumerator ExitGame(){
        yield return new WaitForSeconds(1f);
        Application.Quit();
    }

    IEnumerator StartGame(){
        yield return new WaitForSeconds(1f);
        SceneManager.LoadSceneAsync(sceneName);
    }


    public void BackMenu(){
        animatorCamera.SetBool("Settings",false);
        animatorSettings.SetBool("isOpen",false);
    }
}

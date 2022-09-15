using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuControl : MonoBehaviour
{       
    string name;
    Animator animatorCamera;

    void Start()
    {
        animatorCamera = Camera.main.GetComponent<Animator>();
    }

    void Update()
    {
        //if(Input.GetMouseButtonDown(0))
        CurseFocus(false);

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
                    {
                        Animator animator;

                        animator = target.GetComponent<Animator>();
                        animator.SetTrigger("Turn Head");
                        
                        if(onAnimator)
                            Select(target);

                        
                    }

        }
    }

    void Select(GameObject target){
        UITarget uITarget = target.GetComponent<UITarget>();
            switch(uITarget.Name)
            {
                case "Settings":
                    animatorCamera.SetBool("Settings",true);
                    break;
                case "Start":
                    animatorCamera.SetBool("Close",true);
                    break;
                case "Exit":
                    animatorCamera.SetBool("Close",true);
                    break;
                
            }
    }
}

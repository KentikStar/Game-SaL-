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



    void ChangeAnimator(Mode mode){
        Animator animator = mode.GetComponent<Animator>();
        //animator.SetBool
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }


    public void MoveToSettings(bool animBool)
    {
        animator.SetBool("Settings", animBool);
    }
}

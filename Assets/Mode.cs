using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mode : MonoBehaviour
{
    [SerializeField]
    string modeName;

    string ModeName{get; set;}

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnMouseDown()
    {
        animator.SetBool("Checked", true);
    }
}

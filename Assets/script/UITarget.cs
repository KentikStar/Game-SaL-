using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITarget : MonoBehaviour
{
    Animator animator;

    [SerializeField]
    string nameUI;
    public string NameUI {get{
        return nameUI;
    } set{
        nameUI = value;
    }}

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnMouseEnter()
    {
        animator.SetTrigger("Turn Head");
    }
}

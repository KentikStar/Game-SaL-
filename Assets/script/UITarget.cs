using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITarget : MonoBehaviour
{
    Animator animator;

    [SerializeField]
    string name;
    public string Name {get{
        return name;
    } set{
        name = value;
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

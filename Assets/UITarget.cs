using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITarget : MonoBehaviour
{
    [SerializeField]
    string name;
    public string Name {get{
        return name;
    } set{
        name = value;
    }}
}

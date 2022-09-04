using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inheritanceTransform : MonoBehaviour
{
    [SerializeField]
    Transform parent;

    // Start is called before the first frame update
    void Start()
    {
        transform.eulerAngles = parent.eulerAngles;
        transform.eulerAngles = parent.eulerAngles;
    }

}

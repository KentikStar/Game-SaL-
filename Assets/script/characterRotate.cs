using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterRotate : MonoBehaviour
{
    [SerializeField]
    GameControl gameControl;

    float camSensitivity;


    void Start()
    {
        camSensitivity = gameControl.MouseSens;
    }


    private void Update()
    {
        float rotationX = transform.localEulerAngles.x;
        transform.Rotate(rotationX, Input.GetAxis("Mouse X") * camSensitivity, 0);
    }
}

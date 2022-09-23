using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterRotate : MonoBehaviour
{
    [SerializeField]
    GameControl gameControl;



    private void Update()
    {
        if(!GameControl.IsPaused){
            float rotationX = transform.localEulerAngles.x;
            transform.Rotate(rotationX, Input.GetAxis("Mouse X") * gameControl.MouseSens, 0);
        }
    }
}

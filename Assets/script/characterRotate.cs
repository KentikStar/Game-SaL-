using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterRotate : MonoBehaviour
{
    [SerializeField, Range(0f, 15f)]
    float camSens = 9f; //How sensitive it with mouse
    private Vector3 lastMouse = new Vector3(255, 255, 255); //kind of in the middle of the screen, rather than at the top (play)



    // Update is called once per frame
    void FixedUpdate()
    {
        /*lastMouse = Input.mousePosition - lastMouse;
        lastMouse = new Vector3(-lastMouse.y * camSens, lastMouse.x * camSens, 0);
        lastMouse = new Vector3(0, transform.eulerAngles.y + lastMouse.y, 0);
        transform.eulerAngles = lastMouse;
        lastMouse = Input.mousePosition;*/

        
    }

    private void Update()
    {
        float rotationX = transform.localEulerAngles.x;
        transform.Rotate(rotationX, Input.GetAxis("Mouse X") * camSens, 0);
    }
}

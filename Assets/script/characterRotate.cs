using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterRotate : MonoBehaviour
{
    float camSens = 0.25f; //How sensitive it with mouse
    private Vector3 lastMouse = new Vector3(255, 255, 255); //kind of in the middle of the screen, rather than at the top (play)


    [SerializeField]
    Camera m_Camera;

    Ray getRay()
    {
        return m_Camera.ScreenPointToRay(Input.mousePosition);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        lastMouse = Input.mousePosition - lastMouse;
        lastMouse = new Vector3(-lastMouse.y * camSens, lastMouse.x * camSens, 0);
        lastMouse = new Vector3(0, transform.eulerAngles.y + lastMouse.y, 0);
        transform.eulerAngles = lastMouse;
        lastMouse = Input.mousePosition;
    }
}

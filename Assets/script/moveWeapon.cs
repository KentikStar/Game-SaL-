using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveWeapon : MonoBehaviour
{
    float camSens = 0.25f; //How sensitive it with mouse
    private Vector3 lastMouse = new Vector3(255, 255, 255); //kind of in the middle of the screen, rather than at the top (play)


    [SerializeField]
    Camera m_Camera;

    [SerializeField, Range(0f, 60f)]
    float minRangeCamera;

    [SerializeField, Range(360f, 300f)]
    float maxRangeCamera;

    private void Start()
    {
        Cursor.visible = false;
    }

    Ray getRay()
    {
        return m_Camera.ScreenPointToRay(Input.mousePosition);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        lastMouse = Input.mousePosition - lastMouse;
        

        if (checkValueRotate(transform.eulerAngles.x))
        {
            lastMouse = new Vector3(-lastMouse.y * camSens, lastMouse.x * camSens, 0);
            lastMouse = new Vector3(transform.eulerAngles.x + lastMouse.x, transform.eulerAngles.y, 0);
        }
        else
        {
            lastMouse = new Vector3(-lastMouse.y * camSens * 3, lastMouse.x * camSens * 3, 0);
            lastMouse = new Vector3(transform.eulerAngles.x - lastMouse.x, transform.eulerAngles.y, 0);
        }



        transform.eulerAngles = lastMouse;        
        lastMouse = Input.mousePosition;
    }

    bool checkValueRotate(float value)
    {
        if (value > maxRangeCamera && value < 365)
            return true;
        if (value > -5 && value < minRangeCamera)
            return true;

        return false;
    }
}

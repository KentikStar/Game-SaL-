using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlWeapon : MonoBehaviour
{
    [SerializeField]
    GameObject prefabBullet;

    [SerializeField]
    Transform startPosBullet;

    [SerializeField, Range(0f, 10f)]
    float speedBullet;

    [SerializeField]
    Camera m_Camera;

    [SerializeField, Range(0f, 60f)]
    float minRangeCamera;

    [SerializeField, Range(360f, 300f)]
    float maxRangeCamera;

    float camSens = 0.25f; //How sensitive it with mouse
    private Vector3 lastMouse = new Vector3(255, 255, 255); //kind of in the middle of the screen, rather than at the top (play)

    private void Start()
    {
        Cursor.visible = false;
    }

    Ray getRay()
    {
        Vector3 Ray_start_position = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        return m_Camera.ScreenPointToRay(Ray_start_position);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bullet = Instantiate(prefabBullet, startPosBullet.position,startPosBullet.rotation).gameObject;

            controlBullet controlBullet = bullet.GetComponent<controlBullet>();
            controlBullet.SpeedBullet = speedBullet;
            controlBullet.TargetBullet = getTarget();
        }
    }

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


    Vector3 getTarget()
    {

        RaycastHit raycastHit;

        Physics.Raycast(getRay(), out raycastHit);

        return raycastHit.point;
    }
}

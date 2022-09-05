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

    [SerializeField, Range(360f, 250f)]
    float maxRangeCamera;

    [SerializeField, Range(0f, 15f)]
    float camSens = 9f;

    [SerializeField]
    Animator animator;

    float _rotationX;


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

            animator.SetTrigger("isShot");
        }

        _rotationX -= Input.GetAxis("Mouse Y") * camSens;
        _rotationX = Mathf.Clamp(_rotationX, -45.0f, 45.0f);
        float rotationY = transform.localEulerAngles.y;
        transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
    }

    Vector3 getTarget()
    {

        RaycastHit raycastHit;

        Physics.Raycast(getRay(), out raycastHit);

        return raycastHit.point;
    }
}

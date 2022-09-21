using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlWeapon : MonoBehaviour
{
    [SerializeField]
    controlBullet prefabBullet;

    [SerializeField]
    SoundShot soundShotPrefab;

    [SerializeField]
    Transform startPosBullet;

    [SerializeField, Range(0f, 50f)]
    float speedBullet;

    [SerializeField]
    Camera m_Camera;


    [SerializeField, Range(0f, 45f)]
    float minRangeCamera;

    [SerializeField, Range(-45f, 0f)]
    float maxRangeCamera;


    [SerializeField]
    GameControl gameControl;
    float camSensitivity;

    [SerializeField]
    Animator animator;

    [SerializeField]
    int poolCount = 3;

    [SerializeField]
    bool autoExpand;

    

    float _rotationX;
    PoolMono<controlBullet> poolBullet;
    PoolMono<SoundShot> poolSound;
    bool isShot = true;


    private void Start()
    {
        camSensitivity = gameControl.MouseSens;

        GameObject parentBullet = new GameObject();
        parentBullet.name = "parentBullet";
        poolBullet = new PoolMono<controlBullet>(prefabBullet, poolCount, parentBullet.transform);
        poolBullet.autoExpand = this.autoExpand;

        GameObject parentSound = new GameObject();
        parentSound.name = "parentSound";        
        poolSound = new PoolMono<SoundShot>(soundShotPrefab, poolCount, parentSound.transform);
        poolSound.autoExpand = this.autoExpand;
        parentSound.AddComponent<ParentSoundShot>();
        
    }

    Ray getRay()
    {
        Vector3 Ray_start_position = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        return m_Camera.ScreenPointToRay(Ray_start_position);

        
    }

    // Update is called once per frame
    void Update()
    {
        if(!GameControl.IsPaused){
        
            if (Input.GetMouseButtonDown(0))
            {
                if (isShot)
                {
                    CreateBullet();

                    animator.SetTrigger("isShot");

                    CreateSound();
                    isShot = false;
                    StartCoroutine(waitNextShot());
                }
            }

            RotateX();
        }
    }


    //Поворот оружия по Х
    //��������� "-45"!!!!!!!!!!
    private void RotateX()
    {
        _rotationX -= Input.GetAxis("Mouse Y") * camSensitivity;
        _rotationX = Mathf.Clamp(_rotationX, maxRangeCamera, minRangeCamera);
        float rotationY = transform.localEulerAngles.y;
        transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
    }


    //Взять цель для направления пули
    Vector3 getTarget()
    {

        RaycastHit raycastHit;

        Physics.Raycast(getRay(), out raycastHit);

        return raycastHit.point;
    }

    //Создание пули после выстрела
    private void CreateBullet()
    {
        controlBullet bullet = poolBullet.GetFreeElement();
        bullet.transform.position = startPosBullet.position;
        bullet.SetTarget(getTarget());
        bullet.SpeedBullet = speedBullet;
    }


    //Создание звука выстрела
    private void CreateSound()
    {
        SoundShot sound = poolSound.GetFreeElement();
        sound.transform.position = startPosBullet.position;
        sound.PlaySound();
    }


    //Задержка перед следующим выстрелом
    IEnumerator waitNextShot()
    {
        yield return new WaitForSeconds(0.4f);
        isShot = true;
    }

}

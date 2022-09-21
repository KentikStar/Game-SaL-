using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RapprochementCamera : MonoBehaviour
{

    [SerializeField]
    float rapprochement = 25;
    float defaultView;
    Camera camera;

    void Start()
    {
        camera = Camera.main;
        defaultView = camera.fieldOfView;
    }

    void Update()
    {
        if(!GameControl.IsPaused)
            if(Input.GetMouseButton(1))
                camera.fieldOfView = rapprochement;
            else
                camera.fieldOfView = defaultView;
    }

}

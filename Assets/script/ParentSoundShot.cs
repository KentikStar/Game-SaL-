using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentSoundShot : MonoBehaviour
{
    public float VolumeSound{get; set;}

    // Start is called before the first frame update
    void Start()
    {

    }

    void Awake()
    {
        LoadSettings();
    }


    void LoadSettings(){
        Settings settings;
        SaveSerial saveSerial = new SaveSerial();

        saveSerial.LoadGame(out settings);

        VolumeSound = settings.VolumeSound;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speaker : MonoBehaviour
{
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = LoadSettings();
    }

    float LoadSettings(){
        Settings settings;
        SaveSerial saveSerial = new SaveSerial();

        saveSerial.LoadGame(out settings);

        return settings.VolumeSound;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsContrl : MonoBehaviour
{
    [SerializeField]
    Slider sliderSound, sliderSens;

    public string ModeStr{get; set;}


    // Start is called before the first frame update
    void Start()
    {
        LoadSettings();
    }

    public Settings LoadSettings(){
        Settings settings;
        SaveSerial saveSerial = new SaveSerial();

        saveSerial.LoadGame(out settings);

        sliderSens.value = settings.MouseSens;

        sliderSound.value = settings.VolumeSound;

        ModeStr = settings.Mode;

        return settings;

    }

    void SaveSettings(Settings settings){
        SaveSerial saveSerial = new SaveSerial();
        saveSerial.SaveGame(settings);
    }


    public void ChangeSettings(){
        float valueSens, valueSound;

        valueSens = sliderSens.value;
        valueSound = sliderSound.value;

        Settings settings = new Settings(valueSound, valueSens, ModeStr);

        SaveSettings(settings);
    }

}

public class Settings{

    public float VolumeSound{get; set;}
    public float MouseSens{get; set;}
    public string Mode{get; set;}

    public Settings(float sound, float sens,string mode){
        VolumeSound = sound;
        MouseSens = sens;
        Mode = mode;
    }
}

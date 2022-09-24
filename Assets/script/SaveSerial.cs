using System.Security.Cryptography.X509Certificates;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveSerial : MonoBehaviour
{


public void SaveGame(Settings settings)
{
    BinaryFormatter bf = new BinaryFormatter(); 
    FileStream file = File.Create(Application.persistentDataPath 
        + "/MySaveData.dat"); 
    SaveData data = new SaveData();
    data.VolumeSound = settings.VolumeSound;
    data.MouseSens = settings.MouseSens;
    data.Mode = settings.Mode;
    bf.Serialize(file, data);
    file.Close();
    Debug.Log("Game data saved!");
}

public bool LoadGame(out Settings settings)
{

  if (File.Exists(Application.persistentDataPath 
    + "/MySaveData.dat"))
  {
    BinaryFormatter bf = new BinaryFormatter();
    FileStream file = 
      File.Open(Application.persistentDataPath 
      + "/MySaveData.dat", FileMode.Open);
    SaveData data = (SaveData)bf.Deserialize(file);
    file.Close();
    settings = new Settings(data.VolumeSound,data.MouseSens,data.Mode);
    Debug.Log("Game data loaded!");
    
    return true;    
  }
  else{
    Debug.LogError("There is no save data!");
    settings = new Settings(1,1,"Infinity");
    return false;
  }
}

}



[Serializable]
public class SaveData{
    public float VolumeSound{get; set;}
    public float MouseSens{get; set;}
    public string Mode{get; set;}
}

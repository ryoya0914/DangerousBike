using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

public static class SaveManager {
    public static SaveData saveData;
    public static string saveFileName = "savedata.drs";

    public static void Save()
    {

        BinaryFormatter bf = new BinaryFormatter();
        //DoubleR Savedata (.drs)
        FileStream file = File.Create(Application.persistentDataPath + "/" + SaveManager.saveFileName);
        bf.Serialize(file, SaveManager.saveData);
        file.Close();
    }

    public static void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/" + SaveManager.saveFileName))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/" + SaveManager.saveFileName, FileMode.Open);
            SaveData.Instance = (SaveData)bf.Deserialize(file);
            file.Close();
        }
    }
}

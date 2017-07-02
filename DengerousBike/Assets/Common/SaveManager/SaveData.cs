using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData {
    public static SaveData Instance;
    public string appVersion;

    //Data here-------------------
    public int score;
    //----------------------------

    public SaveData()
    {
        score = 0;
        appVersion = Application.version;
    }
}

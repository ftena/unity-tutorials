using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MainManager: MonoBehaviour
{
    // Start() and Update() methods deleted - we don't need them right now

    // Static instance of GameManager which allows it to be accessed by any other script.
    public static MainManager Instance { get; private set; } // get for the outside, set for the inside

    public Color TeamColor;

    private void Awake()
    {
        /*
        * If you load the Menu scene again later, there will already be one MainManager in existence,
        * so Instance will not be null.
        * In this case, the condition is met: the extra MainManager is destroyed and the script exits there.
        */
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        // The MainManager GameObject attached to this script won't be destroyed when the scene changes.
        DontDestroyOnLoad(gameObject);

        // Load color, stored in a json file, it this file exists.
        LoadColor(); 
    }

    // [System.Serializable] is required for JsonUtility
    [System.Serializable]
    class SaveData
    {
        public Color TeamColor;
    }

    public void SaveColor()
    {
        SaveData data = new SaveData();
        data.TeamColor = TeamColor;

        string json = JsonUtility.ToJson(data);
  
        // File.WriteAllText writes a string to a file
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    } 

    public void LoadColor()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            TeamColor = data.TeamColor;
        }
    }
}


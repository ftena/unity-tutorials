using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameControl: MonoBehaviour
{
    // Start() and Update() methods deleted - we don't need them right now

    // Static instance of GameManager which allows it to be accessed by any other script.
    public static GameControl Instance; 
    public string playerName;
    public int bestScore;

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
        LoadData(); 
    }

    // [System.Serializable] is required for JsonUtility
    [System.Serializable]
    class Data
    {
        public string playerName;
        public int bestScore;
    }

    public void SaveData()
    {
        Data data = new Data();
        data.playerName = playerName;
        data.bestScore = bestScore;

        string json = JsonUtility.ToJson(data);
  
        // File.WriteAllText writes a string to a file
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    } 

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            Data data = JsonUtility.FromJson<Data>(json);

            playerName = data.playerName;
            bestScore = data.bestScore;
        }
    }
}


using UnityEngine;
using System.Collections;

//For serialization, save & load
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameControl : MonoBehaviour
{
    public float health;
    public float experience;

    public static GameControl instance = null;              //Static instance of GameManager which allows it to be accessed by any other script.
    
    void Awake()
    {
        //Check if instance already exists
        if (instance == null)
        {
            //Sets this to not be destroyed when reloading scene
            DontDestroyOnLoad(gameObject);

            //if not, set instance to this
            instance = this;
        }
        else if (instance != this)
        {
            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);
        }        
    }

    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 30), "Health: " + health);
        GUI.Label(new Rect(10, 40, 150, 30), "Exp: " + experience);
    }
	
	public void Save()
	{
		BinaryFormatter bf = new BinaryFormatter();
		//Unity has a persistent data path.
		//It's different depending on the platform.
		//I.e.: in Windows the path is AppData\Roaming...
		FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");
		
		PlayerData data = new PlayerData();
		data.health = health;
		data.experience = experience;
		
		bf.Serialize(file, data);
		file.Close();		
	}
	
	public void Load()
	{
		if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
		{
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);	
			PlayerData data = (PlayerData)bf.Deserialize(file);			
			file.Close();
			
			health = data.health;
			experience = data.experience;			
		}
	}
}

//Class used to be saved to a file.
[Serializable]
class PlayerData
{
	public float health;
	public float experience;
}
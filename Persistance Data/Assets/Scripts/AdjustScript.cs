using UnityEngine;
using System.Collections;

public class AdjustScript : MonoBehaviour {

	void OnGUI()
    {
        if (GUI.Button(new Rect(10, 100, 100, 30), "Health up"))
        {
            GameControl.instance.health += 10;
        }

        if (GUI.Button(new Rect(10, 140, 100, 30), "Health down"))
        {
            GameControl.instance.health -= 10;
        }

        if (GUI.Button(new Rect(10, 180, 100, 30), "Exp up"))
        {
            GameControl.instance.experience += 10;
        }

        if (GUI.Button(new Rect(10, 220, 100, 30), "Exp down"))
        {
            GameControl.instance.experience -= 10;
        }
		
		if (GUI.Button(new Rect(10, 260, 100, 30), "Save"))
        {
            GameControl.instance.Save();
        }
		
		if (GUI.Button(new Rect(10, 300, 100, 30), "Load"))
        {
            GameControl.instance.Load();
        }
    }
}

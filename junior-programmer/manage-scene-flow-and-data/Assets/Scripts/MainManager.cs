using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager: MonoBehaviour
{
    // Start() and Update() methods deleted - we don't need them right now

    // Static instance of GameManager which allows it to be accessed by any other script.
    public static MainManager Instance; 
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
    }
}

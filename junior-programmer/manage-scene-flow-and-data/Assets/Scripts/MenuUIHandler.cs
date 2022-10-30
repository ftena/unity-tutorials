using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
    using UnityEditor; //the namespace will only be included when you are compiling within the Unity Editor.
#endif

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public ColorPicker ColorPicker;

    public void NewColorSelected(Color color)
    {
        MainManager.Instance.TeamColor = color;
    }
    
    private void Start()
    {
        ColorPicker.Init();
        //this will call the NewColorSelected function when the color picker have a color button clicked.
        ColorPicker.onColorChanged += NewColorSelected;
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else   
            // Application.Quit only works in the built application, not when you’re testing in the Editor. 
            Application.Quit();
        #endif
    }
}

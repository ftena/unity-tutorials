using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
    using UnityEditor; //the namespace will only be included when you are compiling within the Unity Editor.
#endif

public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        // This line will save the user’s last selected color when the application exits. 
        // MainManager.Instance.SaveColor(); 

        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else   
            // Application.Quit only works in the built application, not when you’re testing in the Editor. 
            Application.Quit();
        #endif
    }
}

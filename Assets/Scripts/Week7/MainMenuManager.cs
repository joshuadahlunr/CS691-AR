using System;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour {
    public SceneManager manager = null;

    public Button scene1, scene2, quit;

    public void Awake()
    {
        manager = FindObjectsByType<SceneManager>(FindObjectsSortMode.None)[0];
        
        scene1.onClick.AddListener(delegate {
            manager.loadScene1();
        });
        
        scene2.onClick.AddListener(delegate {
            manager.loadScene2();
        });
        
        quit.onClick.AddListener(delegate {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
            Application.Quit();
        });
    }

    
}

using UnityEngine;
using UnityEngine.UI;

public class SharedCanvasManager : MonoBehaviour
{
    public SceneManager manager = null;

    public Button mainMenuButton;

    public void Awake()
    {
        manager = FindObjectsByType<SceneManager>(FindObjectsSortMode.None)[0];

        mainMenuButton.onClick.AddListener(delegate { manager.loadMainMenu(); });
    }
}

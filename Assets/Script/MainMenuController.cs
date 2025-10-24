using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
#endif

public class MainMenuController : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene1.0");
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}

#if UNITY_EDITOR
[InitializeOnLoad]
public static class PlayFromMainMenu
{
    static PlayFromMainMenu()
    {
        EditorApplication.playModeStateChanged += OnPlayModeChanged;
    }

    private static void OnPlayModeChanged(PlayModeStateChange state)
    {
        if (state == PlayModeStateChange.ExitingEditMode)
        {
            string mainMenuScenePath = "Assets/Scenes/MainMenu.unity";


            if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
            {
                EditorSceneManager.OpenScene(mainMenuScenePath);
            }
            else
            {
                EditorApplication.isPlaying = false;
            }
        }
    }
}
#endif
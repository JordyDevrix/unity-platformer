using UnityEngine;
using UnityEngine.SceneManagement;  // For loading scenes

public class MenuManager : MonoBehaviour
{
    // Called when the Start Game button is clicked
    public string scene;

    public void LoadGame()
    {
        // Load the Game Scene (Make sure the scene name matches in Build Settings)
        SceneManager.LoadScene(scene);
    }

    // Called when the Quit button is clicked
    public void QuitGame()
    {
        {
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        }
    }
}

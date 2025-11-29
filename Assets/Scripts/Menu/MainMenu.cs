using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Shooting Range");
    }

    public void Quit()
    {
        // This is so quitting is the same in the editor as it is in the build:
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
}

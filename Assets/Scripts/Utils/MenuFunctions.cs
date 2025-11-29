using UnityEngine;

public static class MenuFunctions
{
    /// <summary>
    /// Quits the game, works both in editor and in build.
    /// </summary>
    public static void Quit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}

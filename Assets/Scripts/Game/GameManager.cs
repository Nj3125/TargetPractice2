using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState { Playing, GameOver }

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public ScoreManager scoreManager;
    public GameState CurrentState { get; private set; }  // Either Playing or GameOver, can be accessed outside this class.

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keeps the game manager around.
        }
        else { Destroy(gameObject); }

        if (scoreManager == null) { Debug.Log("GameManager: No scoreManager assigned in the Inspector!", this); }

        CurrentState = GameState.Playing;
    }

    public void EndGame()
    {
        if (CurrentState == GameState.GameOver) return;
        CurrentState = GameState.GameOver;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        // scoreManager.WriteScoreToFile();
        ShootGun gun = FindObjectOfType<ShootGun>();
        PlayerData data = gun.data;
        Debug.Log(data);
        SaveSystem.Save(data);
        SceneManager.LoadScene("Game Over");
    }
}

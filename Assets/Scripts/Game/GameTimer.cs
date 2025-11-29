using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameTimer : MonoBehaviour
{
    [SerializeField] private TMP_Text timerText;

    [SerializeField] private float gameDuration = 30f;
    private float timeRemaining;

    // Timer starts:
    void Start()
    {
        timeRemaining = gameDuration;
    }

    // Timer ticks down and ends game if timeRemaining = 0:
    void Update()
    {
        if (GameManager.Instance.CurrentState == GameState.GameOver) { return; }
        timeRemaining -= Time.deltaTime;

        if (timeRemaining < 0){ timeRemaining = 0; }
        timerText.text = "Time: " + Mathf.Ceil(timeRemaining).ToString();

        if (timeRemaining <= 0) { GameManager.Instance.EndGame(); }
    }
}

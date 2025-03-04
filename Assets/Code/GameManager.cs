using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public TMP_Text cheeseCounterText;
    public TMP_Text timerText;

    public int totalCheese = 10;
    // public Text cheeseCounterText; // Drag your UI Text here
    public float timeLimit = 180f; // 3 minutes in seconds
    // public Text timerText; // Drag your UI Text here for the timer

    private float timer;

    void Awake()
    {
        // Singleton pattern to ensure there's only one GameManager
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        timer = timeLimit;
        UpdateCheeseCounter();
    }

    void Update()
    {
        timer -= Time.deltaTime;
        UpdateTimerText();

        if (timer <= 0)
        {
            GameOver();
        }
    }

    public void CollectCheese()
    {
        totalCheese--;
        UpdateCheeseCounter();

        if (totalCheese <= 0)
        {
            WinGame();
        }
    }

    void UpdateCheeseCounter()
    {
        cheeseCounterText.text = "Cheese Left: " + totalCheese;
    }

    void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(timer / 60f);
        int seconds = Mathf.FloorToInt(timer % 60f);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void GameOver()
    {
        SceneManager.LoadScene("GameOver"); // Make sure you have a scene named "GameOver"
    }

    void WinGame()
    {
        SceneManager.LoadScene("Win"); // Make sure you have a scene named "Win"
    }
}

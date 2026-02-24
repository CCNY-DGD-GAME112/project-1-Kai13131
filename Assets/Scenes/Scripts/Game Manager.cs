using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI clockText;
    public TextMeshProUGUI scoreText;

    public float timeRemining = 5f * 60f;
    private bool isPaused = false;

    public AudioSource audioSoure;
    public AudioClip audioClip;

    public GameObject enemyPrefab;
    public GameObject coinPrefab;

    public static GameManager Instance;

    public float spawnDuration = 5f;
    public int score = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }


    // Update is called once per frame
    void Update()
    {
        ClockDisplay();

        Spawn();
    }

    public void updateScore()
    {
        score += 10;
        scoreText.text = "Score: " + score.ToString();
    }

    void ClockDisplay()
    {
        //Timer
        if (isPaused) return;

        if (timeRemining < 0f)
        {
            timeRemining = 0f;
            audioSoure.PlayOneShot(audioClip);
            PauseGame();
        }

        timeRemining -= Time.deltaTime;
        int minutes = Mathf.FloorToInt(timeRemining / 60f);
        int seconds = Mathf.FloorToInt(timeRemining % 60f);

        clockText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f;
        Debug.Log("Game Paused");
    }

    void Spawn()
    {
        spawnDuration -= Time.deltaTime;

        if (spawnDuration <= 0f)
        {
            for (int i = 0; i < 5; i++)
            {
                float xVal = Random.Range(-9, 9);
                float yVal = Random.Range(-9, 9);
                Instantiate(enemyPrefab, new Vector3(xVal, yVal, 0), Quaternion.identity);
            }
            spawnDuration = 5f;
        }
        
    }
}

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

    public float spawnDuration = 1f;
    public float spawnColddown = 1f;
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
        //audioSoure.PlayOneShot(audioClip);

        ClockDisplay();

        spawnDuration -= Time.deltaTime;
        if (spawnDuration <= 0f)
        {
            for (int i = 0; i < 5; i++)
            {
                Spawn();
            }
            spawnDuration = spawnColddown;
        }
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
        float xVal = Random.Range(-9f, 9f);
        float yVal = Random.Range(-9f, 9f);
        Instantiate(enemyPrefab, new Vector3(xVal, yVal, 0), Quaternion.identity); 
    }
}

/*
    1. Movement to avoid being damaged;
    2. Collect the coins to get score;
    3. Survive untill times up;

    Layers of juice
    1. The sound when sword attack the enemies
    2. Add ainimation when enemies was damaged
 
 */

using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI clockText;
    public TextMeshProUGUI scoreText;

    public float timeRemining = 5f * 60f;

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

    public void ReStartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void updateScore()
    {
        score += 10;
        scoreText.text = "Score: " + score.ToString();
    }

    void ClockDisplay()
    {
        timeRemining -= Time.deltaTime;
        int minutes = Mathf.FloorToInt(timeRemining / 60f);
        int seconds = Mathf.FloorToInt(timeRemining % 60f);

        clockText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void Spawn()
    {
        Vector2 spawnPosition = GetSpawnPosition();
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }

    Vector2 GetSpawnPosition()
    {
        int Side = Random.Range(0, 4);
        Vector2 spawnPosition = Vector2.zero;
        if (Side == 0)
        {
            spawnPosition = Camera.main.ViewportToWorldPoint(new Vector2(Random.value, 1.1f));
        }
        else if (Side == 1)
        {
            spawnPosition = Camera.main.ViewportToWorldPoint(new Vector2(Random.value, -0.1f));
        }else if(Side == 2)
        {
            spawnPosition = Camera.main.ViewportToWorldPoint(new Vector2(-0.1f,Random.value));
        }else if(Side == 3)
        {
            spawnPosition = Camera.main.ViewportToWorldPoint(new Vector2(1.1f,Random.value));
        }

        return spawnPosition;
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

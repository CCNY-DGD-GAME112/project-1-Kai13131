using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI clockText;
    public TextMeshProUGUI scoreText;

    public float timeRemining = 15f * 60f;
    private bool isPaused = false;

    public AudioSource audioSoure;
    public AudioClip audioClip;

    public GameObject enemyPrefab;

    public static GameManager Instance;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            spawn();
        }
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

    void spawn()
    {
        float xVal = Random.Range(-9, 9);
        float yVal = Random.Range(-9, 9);

        Instantiate(enemyPrefab, new Vector3(xVal, yVal, 0), Quaternion.identity);
    }
}

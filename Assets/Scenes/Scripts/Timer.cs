using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI clockText;

    public float timeRemining = 15f * 60f;
    private bool isPaused = false;

    public AudioSource audioSoure;
    public AudioClip audioClip;

    // Update is called once per frame
    void Update()
    {
        if(isPaused) return;

        if (timeRemining < 0f)
        {
            timeRemining = 0f;
            audioSoure.PlayOneShot(audioClip);
            PauseGame();
        }
        timeRemining -= Time.deltaTime;
        int minutes = Mathf.FloorToInt(timeRemining / 60f);
        int seconds = Mathf.FloorToInt(timeRemining % 60f);

        clockText.text = string.Format("{0:00}:{1:00}", minutes,seconds);

        
    }
    
    void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f;
        Debug.Log("Game Paused");
    }
}

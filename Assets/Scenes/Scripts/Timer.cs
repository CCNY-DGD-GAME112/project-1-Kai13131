using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;

    public float timer = 5f;
    public AudioSource audioSoure;
    public AudioClip audioClip;

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        timerText.text = timer.ToString("F2");
        if(timer <= 0)
        {
            audioSoure.PlayOneShot(audioClip);
            timer = 5f;
        }
    }
}

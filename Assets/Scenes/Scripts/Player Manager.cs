using TMPro;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public float currentHealth = 1f;
    public float maxHealth = 1000f;
    public float speed = 5f;
    public float damageCooldown = 1f;
    private float lastDamageTime = -999f;
    public static PlayerManager Instance;

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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        playerMovement();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(100);
        }
    }

    void TakeDamage(int damage)
    {
        if(Time.time - lastDamageTime < damageCooldown)
        {
            return;
        }
        lastDamageTime = Time.time;
        currentHealth -= damage;

        UpdateHP();

        if (currentHealth <= 0f)
        {
            currentHealth = 0f;
            Die();
        }
    }

    void UpdateHP()
    {
        healthText.text = "HP: " + currentHealth.ToString() + "/" + maxHealth.ToString();
    }

    void Die()
    {
        Destroy(gameObject);
    }

    void playerMovement()
    {
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += new Vector3(0, -speed, 0) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += new Vector3(0, speed, 0) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-speed, 0, 0) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
        }
    }
}

using Unity.VisualScripting;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public float enemyHealth = 100f;
    public float smoothSpeed = 1f;
    public int enemyDamage = 100;

    public static EnemyManager Instance;
    public GameObject scoreCoinPrefab;
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
        

    }

    // Update is called once per frame
    void Update()
    {
        enemyFollow();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Sword"))
        {
            int playerDamage = PlayerManager.Instance.playerDamage;
            enemyHealth -= playerDamage;
            
            if(enemyHealth < 0)
            {
                enemyDie();
            }
        }
    }
    void enemyFollow()
    {
        Vector3 targetPosition = PlayerManager.Instance.gameObject.transform.position;
        transform.position = Vector3.MoveTowards(
            transform.position,
            targetPosition,
            smoothSpeed * Time.deltaTime);
    }
    
    void enemyDie()
    {
        Destroy(gameObject);
        
        Instantiate(scoreCoinPrefab, transform.position, Quaternion.identity);
    }
}

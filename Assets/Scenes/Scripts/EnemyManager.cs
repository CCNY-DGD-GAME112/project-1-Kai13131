using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject player;

    public float smoothSpeed = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enemyFollow();
    }

    void enemyFollow()
    {
        Vector3 targetPosition = player.transform.position;
        transform.position = Vector3.Lerp(
            transform.position,
            targetPosition,
            smoothSpeed * Time.deltaTime);
    }
    
}

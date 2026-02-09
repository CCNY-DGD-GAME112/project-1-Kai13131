using UnityEngine;

public class SwordPivotRotate : MonoBehaviour
{
    public float damage = 10f;
    public float RotateSpeed = 20f;
    public float scale = 1f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float velocity = 1 * Time.deltaTime;

        transform.Rotate(0, 0, RotateSpeed * velocity);
    }
}

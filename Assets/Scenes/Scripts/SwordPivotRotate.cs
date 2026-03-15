using UnityEngine;

public class SwordPivotRotate : MonoBehaviour
{
    public float RotateSpeed = 20f;
    public float scale = 1f;

    // Update is called once per frame
    void Update()
    {
        float velocity = -1 * Time.deltaTime;
        transform.Rotate(0, 0, RotateSpeed * velocity);
    }
}

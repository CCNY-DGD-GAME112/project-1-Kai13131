using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float smoothSpeed = 1f;
    public Vector3 offset = new Vector3 (0, 0, -10);

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = player.position + offset;
        transform.position = Vector3.Lerp(
            transform.position, 
            targetPosition, 
            smoothSpeed * Time.deltaTime);
    }
}

using UnityEngine;

public class cameraFollowPlayer : MonoBehaviour
{
    public GameObject player;

    public float timeOffset;
    public Vector3 posOffset;

    private Vector3 velocity = Vector3.zero;

    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, player.transform.position + posOffset, ref velocity, timeOffset);
    }
}

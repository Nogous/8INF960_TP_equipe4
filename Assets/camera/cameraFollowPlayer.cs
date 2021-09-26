using UnityEngine;

public class cameraFollowPlayer : MonoBehaviour
{
    public Player player;

    public float timeOffset;
    public Vector3 posOffset;

    private Vector3 velocity = Vector3.zero;

    private bool isFalling = false;

    void Update()
    {
        if (player.transform.position.y+ posOffset.y < transform.position.y)
        {
            isFalling = true;
        }

        if (player.isGrounded)
        {
            transform.position = Vector3.SmoothDamp(transform.position, player.transform.position + posOffset, ref velocity, timeOffset);
            isFalling = false;
        }
        else
        {
            if (isFalling)
                transform.position = Vector3.SmoothDamp(transform.position, new Vector3(player.transform.position.x + posOffset.x, player.transform.position.y, transform.position.z + posOffset.z), ref velocity, timeOffset);
            else
                transform.position = Vector3.SmoothDamp(transform.position, new Vector3(player.transform.position.x + posOffset.x, transform.position.y, transform.position.z + posOffset.z), ref velocity, timeOffset);
        }

    }
}

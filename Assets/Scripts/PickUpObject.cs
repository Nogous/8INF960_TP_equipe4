using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("Player")) // collision.CompareTag("Player does not work)
        {
            Destroy(gameObject);
        }
    }

}

using UnityEngine;

public class SlowEnnemies : MonoBehaviour
{
    // Method called when there is a collision between the pickUp object and another
    // GameObject (player for example)
    private void OnTriggerEnter2D(Collider2D other)
    {
        // If the pickUp entered in collision with a GameObject tagged "player", the pickUp
        // is destroyed and disappears
        if (other.gameObject.CompareTag("Player")) // collision.CompareTag("Player does not work)
        {
            GameManager.instance.PickupBonus();
        }
    }
}

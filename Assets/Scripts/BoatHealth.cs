using UnityEngine;

public class BoatHealth : MonoBehaviour
{
    public int health = 100;

    public void TakeDamage(int amount)
    {
        health -= amount;
        Debug.Log("Boat HP: " + health);
    }
}

using UnityEngine;

public class FishMovement : MonoBehaviour
{
    
    public float cooldown;
    public float speed;
    private float remainingCooldown;

    private void Start()
    {
        remainingCooldown = cooldown;
    }
    void Update()
    {
        this.transform.position += Vector3.forward * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);

        if (collision.gameObject.CompareTag("Boat"))
        {
            BoatHealth boat = collision.gameObject.GetComponent<BoatHealth>();

            if (boat != null)
            {
                boat.TakeDamage(10);
            }

            Destroy(gameObject);
        }
    }
}

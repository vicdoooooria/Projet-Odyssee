using UnityEngine;

public class DolphinMovement : MonoBehaviour
{

    public float speed = 5f;
    public float rotationSpeed = 100f;

    public float circleDuration = 3f;
    public float straightDuration = 2f;

    public int maxCycles = 2;

    private float timer = 0f;
    private bool goingStraight = false;
    private int currentCycle = 0;

    public float cooldown;
    private float remainingCooldown;
    private void Start()
    {
        remainingCooldown = cooldown;
    }
    void Update()
    {
        timer += Time.deltaTime;

        if (!goingStraight)
        {
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
            transform.position += transform.forward * speed * Time.deltaTime;

            if (timer >= circleDuration)
            {
                goingStraight = true;
                timer = 0f;
            }
        }
        
        else
        {
            transform.position += transform.forward * speed * Time.deltaTime;

            if (timer >= straightDuration)
            {
                goingStraight = false;
                timer = 0f;
                currentCycle++;

                if (currentCycle >= maxCycles)
                {
                    goingStraight = true;
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        print(collision.gameObject.name);

        if (collision.gameObject.tag == "Boat")
        {
            BoatHealth boat = collision.gameObject.GetComponent<BoatHealth>();

            if (boat != null)
            {
                boat.TakeDamage(10);
            }

            Destroy(this.gameObject);
        }
    }
}
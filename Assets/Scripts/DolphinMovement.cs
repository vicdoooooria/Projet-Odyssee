using UnityEngine;

public class DolphinMovement : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 100f;

    public float straightDuration = 2f;
    public int maxCycles = 2;

    private float timer = 0f;
    private bool goingStraight = false;
    private int currentCycle = 0;

    private float rotatedAngle = 0f;

    void Update()
    {
        if (!goingStraight)
        {
            float rotationStep = rotationSpeed * Time.deltaTime;
            transform.Rotate(Vector3.up * rotationStep);
            rotatedAngle += rotationStep;

            transform.position += transform.forward * speed * Time.deltaTime;

            if (rotatedAngle >= 360f)
            {
                goingStraight = true;
                timer = 0f;
                rotatedAngle = 0f;
            }
        }
        else
        {
            transform.position += transform.forward * speed * Time.deltaTime;
            timer += Time.deltaTime;

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
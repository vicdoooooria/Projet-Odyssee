using UnityEngine;

public class TridentController : MonoBehaviour
{

    public float speed;

    void Update()
    {
        this.transform.position += Vector3.forward * speed * Time.deltaTime;
    }
    private void OnCollisionEnter(Collision collision)
    {
        print(collision.gameObject.name);

        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}
// rajouter un nombre maximal de tirs par seconde
using UnityEngine;

public class TridentController : MonoBehaviour
{

    public float speed;

    // Update is called once per frame
    void Update()
    {
        this.transform.position += Vector3.forward * speed * Time.deltaTime;
    }
    private void OnCollisionEnter(Collision collision)
    {
        print(collision.gameObject.name);

        if (collision.gameObject.tag == "Enemy")
        {
            // kill enemy
            Destroy(collision.gameObject);
            // kill trident
            Destroy(this.gameObject);
        }
    }
}
// rajouter un nombre maximal de tirs par seconde
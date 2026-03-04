using UnityEngine;

public class BulletController : MonoBehaviour
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
            // kill ennemy
            Destroy(collision.gameObject);
            // kill bullet
            Destroy(this.gameObject);
        }
    }
}
// rajouter un nombre maximal de tire par seconde
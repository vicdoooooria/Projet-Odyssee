using UnityEngine;

public class FireArrow : MonoBehaviour
{

    public float speed;
    private AudioSource audioSource;

<<<<<<< HEAD
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }
    // Update is called once per frame
=======
>>>>>>> 0d08fe3fae5ef3af3e6b541041b1830c43e76592
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
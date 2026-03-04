using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public InputActionReference fireAction;
    public InputActionReference moveAction;
    public GameObject bulletPrefab;

    // Update is called once per frame
    void Update()
    {
        print("Virtual stick : " + moveAction.action.ReadValue<Vector2>());

        Vector3 tempPos = new Vector3(moveAction.action.ReadValue<Vector2>().x, 0, 0);

        this.transform.position += tempPos * speed * Time.deltaTime;

        if (fireAction.action.triggered)
        {
            print("Fire pressed");
            Instantiate(bulletPrefab, this.transform.position, Quaternion.identity);
        }
    }
}


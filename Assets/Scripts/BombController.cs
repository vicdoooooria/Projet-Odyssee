using UnityEngine;
using UnityEngine.InputSystem;

public class BombController : MonoBehaviour
{
    public GameObject projectilePrefab; //projectile qui sera instantiate
    public float force;
    public InputActionReference clickAction;
    public InputActionReference mousePositionAction;

    // Update is called once per frame
    void Update()
    {
        if(clickAction.action.triggered)
        {
            Vector2 mousePosition = mousePositionAction.action.ReadValue<Vector2>();
            Vector3 camToWorldPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, 10));
            SpawnProjectile(camToWorldPosition);
        }
    }

    void SpawnProjectile(Vector3 targetPosition)
    {
        GameObject projectileSpawned = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        Rigidbody2D rigid = projectileSpawned.GetComponent<Rigidbody2D>();
        Vector3 direction = (targetPosition - transform.position).normalized;
        rigid.AddForce(direction * force, ForceMode2D.Impulse);
    }
}
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
            //converti la position de la souris a l'ecran, en position dans le registre du world
            Vector3 camToWorldPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, 10));
            
            print("mouse position = " + mousePosition + "world position = " + camToWorldPosition);
            SpawnProjectile(camToWorldPosition); //spawn un projectile a la position fournie en param1
        }
    }

    void SpawnProjectile(Vector3 spawnPos) //prend un vector3 en parametre, correspond a la position du instatiate
    {
        GameObject projectileSpawned = Instantiate(projectilePrefab, spawnPos, Quaternion.identity); //spawn du projectile et on le stocke dans une variable locale
        
        Rigidbody2D rigid = projectileSpawned.GetComponent<Rigidbody2D>(); //recupere le ridid body du boulet
        rigid.AddForce(Vector3.right * force); //acces a la fonction addForce du Rigidbody
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTurretBul : MonoBehaviour
{
    private Turret turret;
    public int damage;
    private void Awake()
    {
        turret = FindFirstObjectByType<Turret>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {

            EnemyAi enemy = collision.collider.GetComponent<EnemyAi>();
            enemy.takeDamage(damage);
            Destroy(gameObject);
        }
    }
   
}

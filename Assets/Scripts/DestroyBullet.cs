using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class DestroyBullet : MonoBehaviour
{
    private EnemyAi enemyAi;
    private EnemyAutoShoot playergun;
    public int damage;


    private void Awake()
    {
        playergun = FindFirstObjectByType<EnemyAutoShoot>();
        enemyAi = FindFirstObjectByType<EnemyAi>();
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

using UnityEngine;

public class PlayerHouse : MonoBehaviour
{
    [SerializeField] private int houseHealth;
    [SerializeField] private int maxHealth;


    private void takeDamage(int damage)
    {
        houseHealth -= damage;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyAi enemy = other.GetComponent<EnemyAi>();
            takeDamage(enemy.dealDamage);
            Destroy(enemy.gameObject);
        }
    }
}

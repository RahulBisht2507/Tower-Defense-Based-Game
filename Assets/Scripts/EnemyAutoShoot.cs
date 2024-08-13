using UnityEngine;
using System.Collections.Generic;
using static UnityEngine.GraphicsBuffer;

public class EnemyAutoShoot : MonoBehaviour
{
    [SerializeField] public Transform player; // Reference to the player's transform
    [SerializeField] public GameObject bulletPrefab; // Prefab of the bullet to be shot
  /*  [SerializeField] public float shootingRange = 10f; // Range within which the enemy can shoot*/
    [SerializeField] public float shootingInterval = 1f; // Time interval between shots
    [SerializeField] public Transform firePoint; // Point from where bullets are fired
    [SerializeField] public bool EnemyInRange;
    [SerializeField] private float speed;
    /*[SerializeField] private LayerMask whatIsEnemy;*/

    public int Damage = 1;
    [SerializeField]public EnemyAi currentEnemyTarget;
    private float shootingTimer = 0f;                                       // Timer to control shooting intervals
    public List<EnemyAi> targets = new List<EnemyAi>();

    void Update()
    {
        CurrentEnemyTarget();

        

        if (currentEnemyTarget != null)
        {
            if (currentEnemyTarget.health <= 0)
            {
                targets.Remove(currentEnemyTarget);
            }
            RotateTowardsTarget();
            if (shootingTimer <= 0f)
            {
                Shoot(); // Shoot at the player
                shootingTimer = shootingInterval; // Reset the timer
            }
            else
            {
                shootingTimer -= Time.deltaTime; // Count down the timer
            }

        }

    }

    private void CurrentEnemyTarget()
    {
        if (targets.Count <= 0)
        {
            currentEnemyTarget = null;
            return;
        }
        currentEnemyTarget = targets[0];
        
    }
    private void RotateTowardsTarget()
    {
    if(currentEnemyTarget == null)
        {
            return;
        }


        Vector3 direction = currentEnemyTarget.transform.position - player.transform.position;
        direction.y = 0f; // Ensure the rotation is horizontal
        Quaternion targetRotation = Quaternion.LookRotation(direction);
       /* player.LookAt(currentEnemyTarget.transform);*/
        player.transform.rotation = Quaternion.Lerp(player.transform.rotation, targetRotation, Time.deltaTime * speed);
    }
    void Shoot()
    {
        // Instantiate a bullet at the firePoint position and rotation
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        // Add velocity to the bullet (for example, if the bullet has a Rigidbody component)
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 50f;
        DestroyBullet dam = bullet.GetComponent<DestroyBullet>();
        dam.damage = Damage;

        // Destroy the bullet after some time (if needed)
        Destroy(bullet, 2f);
        // Optionally, add logic to damage the player here
    }
    /*private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, range);
    }*/

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
           EnemyAi newEnemy = other.GetComponent<EnemyAi>();
            targets.Add(newEnemy);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {

            EnemyAi oldEnemy = other.GetComponent<EnemyAi>();

            if (targets.Contains(oldEnemy)) 
            {
                targets.Remove(oldEnemy);
            }
        }
    }

}

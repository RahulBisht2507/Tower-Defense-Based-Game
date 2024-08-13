using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PLayerHealth : MonoBehaviour
{
    [SerializeField] private int playerhealth = 3;
    [SerializeField] private int maxHealth = 3;
    [SerializeField] private Image[] image;
    /*[SerializeField] private 
    [SerializeField] private 
    [SerializeField] private */

    void TakeDamage(int damage)
    {
        if (playerhealth > 0)
        {
            image[maxHealth - playerhealth].gameObject.SetActive(false);
            playerhealth -= damage;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            TakeDamage(1);
        }
    }
}

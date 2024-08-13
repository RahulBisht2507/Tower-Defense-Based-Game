using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckArea : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyspawner;
    [SerializeField] private float rad;
    [SerializeField] private LayerMask layerMask;
    public int wave = 1;
    public bool enemyInArea;
    void Update()
    {
        enemyInArea = Physics.CheckSphere(transform.position, rad,layerMask);
        if (!enemyInArea && wave ==1)
        {
            enemyspawner[wave-1].SetActive(true);
            Invoke("IncreWave", 2);
        }
        if (!enemyInArea && wave == 2)
        {
            enemyspawner[wave-1].SetActive(true);
            Invoke("incre", 2);
        }
        if (!enemyInArea && wave == 3)
        {
            enemyspawner[wave-1].SetActive(true);
        }
    }

    private void IncreWave()
    {
        if (wave == 1)
        {
            wave = 2;
           
        }
    }
    private void incre()
    {
        if (wave == 2)
        {
            wave = 3;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, rad);
    }
}

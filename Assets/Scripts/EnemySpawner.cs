using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]public int enemyCount;
    [SerializeField] private float spawnIntervals;
    [SerializeField]private float spawnTimer;
    [SerializeField]private int enemiesSpawned;
    [SerializeField] private CheckArea area;

   /* private ObjectPooler pooler;*/

    private void Awake()
    {
        /*pooler = GetComponent<ObjectPooler>();*/
    }

    private void Update()
    {

        spawnTimer -=  Time.deltaTime;
        if (spawnTimer < 0)
        {
            spawnTimer = spawnIntervals;
            if(enemiesSpawned < enemyCount)
            {
                enemiesSpawned++;
                SpawnEnemy();
            }
        }
    }

    private void SpawnEnemy() 
    {
        GameObject newinstance = ObjectPooler.instance.GetPooledObeccts();
        newinstance.SetActive(true);
    }

}

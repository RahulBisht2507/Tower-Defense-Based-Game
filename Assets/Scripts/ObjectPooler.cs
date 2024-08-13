using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField]private List<GameObject> ListOfEnemy;
    public static ObjectPooler instance;
    [SerializeField] private EnemySpawner spawner;
    [SerializeField] private Transform spawntransform;
    private void Awake()
    {
        spawner = GetComponent<EnemySpawner>();
        ListOfEnemy = new List<GameObject>();
        instance = GetComponent<ObjectPooler>();

        if (instance != null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        for (int i = 0; i < spawner.enemyCount; i++)
        {
            GameObject obj = Instantiate(enemy,spawntransform.position,Quaternion.identity);
            obj.SetActive(false);
            ListOfEnemy.Add(obj);
        }
    }

    public GameObject GetPooledObeccts()
    {
        for (int i = 0; i < ListOfEnemy.Count; i++)
        {
            if (!ListOfEnemy[i].activeInHierarchy)
            {
                return ListOfEnemy[i];
            }
        }
        return null;
    }

}

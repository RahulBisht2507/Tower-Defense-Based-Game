using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class EnemyAi : MonoBehaviour
{
    private EnemySpawner spawner;
    private NavMeshAgent nav;
    public List<GameObject> waypoints;
    [SerializeField] public float health;
    [SerializeField] private Slider healthbar;
    [SerializeField] private GameObject Coin;
    private GameObject PlayerHouse;
    public static  int CointAtDeath;
 

    public int dealDamage = 1;
    public int index = 0;
    private Vector3 direction;

    private void Awake()
    {
        spawner = FindAnyObjectByType<EnemySpawner>();
        waypoints[0] = GameObject.Find("1");
        waypoints[1] = GameObject.Find("2");
        waypoints[2] = GameObject.Find("3");
        waypoints[3] = GameObject.Find("4");
        waypoints[4] = GameObject.Find("5");
        waypoints[5] = GameObject.Find("6");
        PlayerHouse = GameObject.Find("Playerhouse");
        nav = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        healthbar.value = health;
        

        UpdatePos();
        if(health <=0)
        {
            /*Instantiate(Coin, transform.position, Quaternion.identity);*/
            Delete();
        }
    }
    private void UpdatePos()
    {
        // Calculate the direction towards the target
        direction = waypoints[index].transform.position - transform.position;
        direction.y = 0f;
        direction.Normalize();

        // Calculate the desired rotation based on the direction
        Quaternion targetRotation = Quaternion.LookRotation(direction);

        // Smoothly rotate the AI vehicle towards the desired rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 2f);

        // Move the AI vehicle forward
        transform.Translate(Vector3.forward * 5 * Time.deltaTime);
        float distance = Vector3.Distance(waypoints[index].transform.position, transform.position);



        if (distance <= 5)
        {
            if (index < waypoints.Count - 1)
            {
                index++;
            }
            /*else
            {
                if (isLoop)
                {
                    index--;
                }
            }*/
        }
    }
    private void Delete()
    {
        Instantiate(Coin,transform.position,Quaternion.identity);
        transform.position = spawner.transform.position;
        gameObject.SetActive(false);
    }

   
    public void takeDamage(float damage)
    {
        if(health>=0) health -= damage;
    }


}

using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject EnemyObjectToSpawn;
    public GameObject Player;
    [SerializeField] private List<GameObject> Enemies = new List<GameObject>();
    [SerializeField] private GameObject NearestEnemy = null;


    void Start()
    {
       Player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        CleanUpEnemy();
        FindNearestEnemy();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            RemoveNearestEnemy();
        }
    }

    public void SpawnEnemy()
    {
        Vector3 spawnPosition;

        do
        {

            Vector3 RandomDistance = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f));
            RandomDistance.Normalize();

            float RangedDistance = Random.Range(10f, 20f);

            spawnPosition = Player.transform.position + RandomDistance * RangedDistance;


        }
        while (IsPositionOccupied(spawnPosition));

        GameObject NewEnemy = Instantiate(EnemyObjectToSpawn, spawnPosition, Quaternion.identity);
        Debug.Log(Enemies);
        Enemies.Add(NewEnemy);
    }

    

    bool IsPositionOccupied(Vector3 position)
    {
        foreach (GameObject enemy in Enemies) { 
            if(enemy != null && Vector3.Distance(position, enemy.transform.position) < 1f)
            {
                return true;
            }
        }
        return false;
    }

    private void FindNearestEnemy()
    {
        float distanceToNearEnemy = Mathf.Infinity;
        NearestEnemy = null;

        foreach (GameObject currentEnemy in Enemies)
        {
            if(currentEnemy == null) continue;

            float distanceToCurrentEnemy = Vector3.Distance(Player.transform.position, currentEnemy.transform.position);

            if(distanceToCurrentEnemy < distanceToNearEnemy)
            {
                distanceToNearEnemy = distanceToCurrentEnemy;
                NearestEnemy = currentEnemy;
            }

            if(NearestEnemy != null)
            {
                Debug.Log("Найближчий ворог:" + NearestEnemy.name);
            }
        }
    } 
    public void RemoveEnemyFunction(GameObject enemy)
    {
        if (enemy != null)
        {
            Enemies.Remove(enemy);
            Destroy(enemy);
        }
    }

    private void RemoveNearestEnemy ()
    {
        if(NearestEnemy != null)
        {
            RemoveEnemyFunction(NearestEnemy);
        }
    }

    
    private void CleanUpEnemy()
    {
        Enemies.RemoveAll(enemy => enemy = null);
    }









}
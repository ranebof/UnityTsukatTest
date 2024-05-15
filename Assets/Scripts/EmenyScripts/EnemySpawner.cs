using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject EnemyObjectToSpawn; 
    public GameObject Player; 
    List<GameObject> Enemies = new List<GameObject>(); 

    public void SpawnEnemy()
    {
        Vector3 spawnPosition;

        do
        {
            
            Vector3 RandomDistance = new Vector3(Random.Range(-1f,1f), 0f, Random.Range(-1f,1f));
            RandomDistance.Normalize();

            float RangedDistance = Random.Range(10f, 20f);
            
            spawnPosition = Player.transform.position + RandomDistance * RangedDistance; 
            
            //Debug.Log(spawnPosition);

        }
        while (IsPositionOccupied(spawnPosition));


        GameObject NewEnemy = Instantiate(EnemyObjectToSpawn, spawnPosition, Quaternion.identity);
        Enemies.Add(NewEnemy); 
    }

    bool IsPositionOccupied(Vector3 position)
    {
        foreach (GameObject enemy in Enemies)
        {
            if (Vector3.Distance(position, enemy.transform.position) < 1)
            {
                return true;
            }
        }

        return false;
    }
}
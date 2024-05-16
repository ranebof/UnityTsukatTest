using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NearestObjectDestroy : MonoBehaviour
{
    public GameObject[] AllEnemies;
    public GameObject NearestEnemy;

    float distance;
    float nearestObjectDistance;

    void Start()
    {
        AllEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        
    }

    void Update()
    {
        
    }
}

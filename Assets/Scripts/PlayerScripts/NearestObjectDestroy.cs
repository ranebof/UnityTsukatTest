/*using UnityEngine;

public class NearestObjectDestroy : MonoBehaviour
{
    public GameObject Player;
    public GameObject NearestEnemy = null;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        NearestEnemyFucnt();

        if(Input.GetKeyDown(KeyCode.Space)) {
            
        }
    }

    void NearestEnemyFucnt()
    {
        float distanceToNearestEnemy = Mathf.Infinity;
        GameObject[] allEnemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject currentEnemy in allEnemies)
        {
            float distanceToCurrentEnemy = Vector3.Distance(Player.transform.position, currentEnemy.transform.position);
            if (distanceToCurrentEnemy < distanceToNearestEnemy)
            {
                distanceToNearestEnemy = distanceToCurrentEnemy;
                NearestEnemy = currentEnemy;
            }
        }

        if (NearestEnemy != null)
        {
            Debug.Log("Nearest Enemy: " + NearestEnemy.name);
        }       
    }
}
*/
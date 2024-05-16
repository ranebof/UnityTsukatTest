using UnityEngine;
using UnityEngine.AI;
public class EnemyMoving : MonoBehaviour
{
    public NavMeshAgent enemy;
    public GameObject PlayerObject;
    public GameObject bulletPrefab;

    public float bulletRate = 1.0f;
    public float nextFireTime = 0.0f;

    void Start()
    {
        enemy = GetComponent<NavMeshAgent>();
        PlayerObject = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        enemy.SetDestination(PlayerObject.transform.position);

        if(Time.time > nextFireTime)
        {
            Fire();
            nextFireTime = Time.time + 1.0f / bulletRate;
        }
    }

    void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

        bullet.GetComponent<BulletScript>().player = PlayerObject;
    }
}

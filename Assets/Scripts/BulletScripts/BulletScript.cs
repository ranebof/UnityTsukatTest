using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed = 10f;
    public GameObject player;
    private Vector3 direction;

    void Start()
    {
        direction = (player.transform.position - transform.position).normalized;
    }

    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            Destroy(gameObject);
            player.GetComponent<PlayerMovement>().MakeDamage(10);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float bulletSpeed = 1f;
    [SerializeField] private GameObject enemyBulletImpact;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        rb.velocity = Vector2.down * bulletSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Instantiate(enemyBulletImpact, collision.transform.position, collision.transform.rotation);
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}

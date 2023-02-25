using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float speed = 1.0f;
    private Transform bulletTransform;
    [SerializeField] private GameObject bulletImpact;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        bulletTransform = GetComponent<Transform>();
    }

    void Start()
    {
        rb.velocity = bulletTransform.up * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Instantiate(bulletImpact, collision.transform.position, collision.transform.rotation);
            ScoreManager.instance.AddScore();

            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}

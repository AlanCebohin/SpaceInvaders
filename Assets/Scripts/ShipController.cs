using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    [Header("Player Settings")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float playerOffset = 0.5f;
    private Transform playerTransform;

    private CameraSettings cameraSettings;

    [Header("Bullet Settings")]
    [SerializeField] private BulletController bulletController;
    [SerializeField] private Transform transformBulletPoint;
    [SerializeField] private float shootCooldownCounter;

    // @TODO: Play with ShootCooldownTime when difficulty increased.
    [SerializeField] private float shootCooldownTime = 1f;
    [SerializeField] private float shootCounterTime = 0.5f;
    [SerializeField] private float shootCounter;
    private bool canShoot = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerTransform = GetComponent<Transform>();
        transformBulletPoint = GameObject.Find("BulletPoint").GetComponent<Transform>();
    }

    private void Start()
    {
        cameraSettings = Camera.main.GetComponent<CameraSettings>();
    }

    void Update()
    {
        Move();
        Shoot();
    }

    private void Move()
    {
        float movementX = Input.GetAxisRaw("Horizontal") * moveSpeed;
        rb.velocity = new Vector2(movementX, rb.velocity.y);

        cameraSettings.SetLimitBound(playerTransform, playerOffset);
        
        /** Replace with this this for the ship to move in the Y axis: */
        // float movementX = Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime;
        // float movementY = Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime;

        // rb.transform.Translate(movementX, movementY, 0);
    }

    private void Shoot()
    {
        if (shootCooldownCounter > 0)
            shootCooldownCounter -= Time.deltaTime;
        else
        {
            if (Input.GetButtonDown("Fire1") && canShoot)
            {
                Instantiate(bulletController, transformBulletPoint.position, transformBulletPoint.rotation);
                shootCounter = shootCounterTime;
                canShoot = false;
            }
        }

        if (shootCounter > 0)
        {
            shootCounter -= Time.deltaTime;
            canShoot = true;
            shootCooldownCounter = shootCooldownTime;
        }
    }

}

using UnityEngine;

public class EnemyAttackController : MonoBehaviour
{
    [Header("Enemy Movement Settings")]
    [SerializeField] private float offsetY = 1;
    private EnemyMoveController enemyContainer;
    private Transform enemyTransform;

    [Header("Enemy Attack Settings")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float shootTime = 2f;
    private float shootTimeCounter;
    [SerializeField] private float cooldownTime = 12f;
    private float cooldownTimeCounter, random;

    private void Awake()
    {
        enemyTransform = GetComponent<Transform>();
    }

    private void Start()
    {
        enemyContainer = enemyTransform.parent.GetComponent<EnemyMoveController>();
    }

    void Update()
    {
        enemyContainer.Move(enemyTransform);
        Shoot();
    }

    private void Shoot()
    {
        // Enemies shoot if the random number and cooldown equals to 0
        random = Random.Range(0f, 2000f);
        if (shootTimeCounter > 0)
        {
            shootTimeCounter -= Time.deltaTime;
        }
        else if (random < 1 && shootTimeCounter <= 0)
        {
            Instantiate(bulletPrefab, new Vector2(enemyTransform.position.x, enemyTransform.position.y - offsetY), Quaternion.identity);
            cooldownTimeCounter = cooldownTime;
        }
        if (cooldownTimeCounter > 0)
        {
            cooldownTimeCounter -= Time.deltaTime;
            shootTimeCounter = shootTime;
        }
    }
}

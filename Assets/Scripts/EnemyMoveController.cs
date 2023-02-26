using UnityEngine;

public class EnemyMoveController : MonoBehaviour
{
    [Header("Enemy Movement Settings")]
    private Transform enemyContainerTransform;

    public static EnemyMoveController instance;
    public bool IsMoving { get => _isMoving; set => _isMoving = value; }
    private bool _isMoving = true;
    private float enemyOffset = .5f, timer = 0f;

    // @TODO: Play with ShootCooldownTime when difficulty increased.
    [SerializeField] private float spaceUnits = 0.1f, movingTime = 5f;

    private float leftViewportLimit;
    private float rightViewportLimit;

    private void Awake()
    {
        instance = this;
        enemyContainerTransform = GetComponent<Transform>();
    }

    private void Start()
    {
        leftViewportLimit = Camera.main.ViewportToWorldPoint(Vector3.zero).x + enemyOffset;
        rightViewportLimit = Camera.main.ViewportToWorldPoint(Vector3.one).x - enemyOffset;
    }

    public void Move(Transform ememyTransform)
    {
        if (_isMoving)
        {
            // Move enemies in the x axis if they reach the camera's edges
            timer += Time.deltaTime;
            if (timer > movingTime)
            {
                enemyContainerTransform.Translate(new Vector2(spaceUnits, 0));
                timer = 0f;
            }

            // Move all enemies down if one of them reach the camera's edges
            if (ememyTransform.position.x <= leftViewportLimit || ememyTransform.position.x >= rightViewportLimit)
            {
                spaceUnits *= -1;
                enemyContainerTransform.Translate(new Vector2(spaceUnits, -1));

                timer = 0f;
            }
        }

    }
}

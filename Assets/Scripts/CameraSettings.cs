using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSettings : MonoBehaviour
{
    [SerializeField] private int targetFrameRate = 60;
    private float cameraVerticalSize, cameraHorizontalSize;
    private float gameObjectOffset;
    private Transform gameObjectTransform;

    [Header("Camera Settings")]
    private float leftViewportLimit;
    private float rightViewportLimit;

    private void Awake()
    {
        Application.targetFrameRate = targetFrameRate;
        cameraVerticalSize = Camera.main.orthographicSize;
        cameraHorizontalSize = cameraVerticalSize * Camera.main.aspect;
    }

    private void Start()
    {
        leftViewportLimit = Camera.main.ViewportToWorldPoint(Vector3.zero).x;
        rightViewportLimit = Camera.main.ViewportToWorldPoint(Vector3.one).x;
    }

    public void SetLimitBound(Transform gameObjectTransform, float gameObjectOffset)
    {
        if (gameObjectTransform.position.x <= (leftViewportLimit + gameObjectOffset))
        {
            SetMovementLimit(leftViewportLimit + gameObjectOffset, gameObjectTransform);
        }
        else if (gameObjectTransform.position.x >= (rightViewportLimit - gameObjectOffset))
            SetMovementLimit(rightViewportLimit - gameObjectOffset, gameObjectTransform);
    }

    private void SetMovementLimit(float limit, Transform gameObjectTransform)
    {
        gameObjectTransform.position = new Vector2(limit, gameObjectTransform.position.y);
    }
}

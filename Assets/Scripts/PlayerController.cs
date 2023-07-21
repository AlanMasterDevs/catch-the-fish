using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool IsMoving { get => _isMoving; set => _isMoving = value; }
    private bool _isMoving;

    [SerializeField]
    private float movementSpeed;
    private Transform playerTransform;

    private float leftViewportLimit;
    private float rightViewportLimit;

    private float playerOffset = 2;

    void Start()
    {
        playerTransform = GetComponent<Transform>();
        leftViewportLimit = Camera.main.ViewportToWorldPoint(Vector3.zero).x + playerOffset;
        rightViewportLimit = Camera.main.ViewportToWorldPoint(Vector3.one).x - playerOffset;
    }

    void Update()
    {
        if (_isMoving)
            SetMovement();

        if (transform.position.x < leftViewportLimit)
            SetLimitPlayerPosition(leftViewportLimit);
        else if (transform.position.x > rightViewportLimit)
            SetLimitPlayerPosition(rightViewportLimit);
    }

    private void SetLimitPlayerPosition(float limit)
    {
        playerTransform.position = new Vector3(limit, playerTransform.position.y, 0);
    }

    private void SetMovement()
    {
        float inputX = Input.GetAxis("Horizontal");
        playerTransform.position += Vector3.right * (inputX * movementSpeed * Time.deltaTime);
    }
}

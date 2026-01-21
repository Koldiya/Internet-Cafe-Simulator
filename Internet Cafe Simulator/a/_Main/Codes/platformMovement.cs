using System;
using UnityEngine;

public class platformMovement : MonoBehaviour
{
    [SerializeField] float speed;
    Rigidbody2D platformRb;

    private void Awake()
    {
        platformRb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        platformRb.linearVelocity = Vector2.left * speed * 100 * Time.fixedDeltaTime;
    }
}

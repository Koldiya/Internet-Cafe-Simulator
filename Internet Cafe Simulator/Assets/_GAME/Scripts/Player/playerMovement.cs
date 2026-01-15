using UnityEngine;

public class playerMovement : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField] float moveSpeed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = inputManager.Instance.getMovementInput().normalized * moveSpeed * 100 * Time.fixedDeltaTime;
    }
}

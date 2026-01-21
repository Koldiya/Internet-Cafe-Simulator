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
        Vector2 input = inputManager.Instance.getMovementInput();

        if(input.x > 0) transform.eulerAngles = Vector3.up * 0;
        else if (input.x < 0) transform.eulerAngles = Vector3.up * 180;

        rb.linearVelocity = input.normalized * moveSpeed * 100 * Time.fixedDeltaTime;
    }
}

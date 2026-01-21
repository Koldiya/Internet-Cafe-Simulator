using System.Collections;
using UnityEngine;

public class charMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D CharRb;
    [SerializeField] float spehereRadius, charSpeed, sphereOrigin;
    [SerializeField] LayerMask groundLayer;
    bool isGround;
    Animator anim;
    private void Awake()
    {
        CharRb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        int count = 0;

        Collider2D[] gays = Physics2D.OverlapCircleAll(transform.position + Vector3.down * sphereOrigin, spehereRadius);

        foreach (Collider2D gay in gays)
        {
            if (gay.CompareTag("Platform"))
            {
                isGround = true;
                count++;
            }
        }
        if (count == 0)
        {
            isGround = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            CharRb.linearVelocityY = 0;
            CharRb.AddForceY(400);
        }

        anim.SetBool("Jumping", isGround);

        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        transform.Translate(input.x * charSpeed * Time.deltaTime, 0, 0);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + Vector3.down * sphereOrigin, spehereRadius);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Trigger"))
        {
            Time.timeScale = 0;
        }
    }
}
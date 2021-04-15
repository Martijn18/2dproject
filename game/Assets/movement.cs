using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float speed;
    public Animator animator;
    public float jumpforce;
    private float moveinput;

    private Rigidbody2D rb;

    private bool facingright = true;

    private bool isgrounded;
    public Transform groundcheck;
    public float checkradius;
    public LayerMask whatisground;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    private void Update()
    {
        animator.SetFloat("speed", Mathf.Abs(moveinput));
        if (Input.GetKeyDown(KeyCode.Space) && isgrounded == true)
        {
            animator.SetBool("isjumping", true);
            rb.velocity = Vector2.up * jumpforce;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (isgrounded == true)
        {
            animator.SetBool("isjumping", false);
        }
    }
    private void FixedUpdate()
    {
        isgrounded = Physics2D.OverlapCircle(groundcheck.position, checkradius, whatisground);
    

        moveinput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveinput * speed, rb.velocity.y);
        if(facingright == false && moveinput > 0) {
            Flip();
        } else if(facingright == true && moveinput < 0)
            {
            Flip(); 
            }
    }

    void Flip()
    {
        facingright = !facingright;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}

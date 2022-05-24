using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float movementSpeed = 1f;
    public float jumpForce = 5f;
    public bool touchW = false;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(new Vector2(movementSpeed, 0f), ForceMode2D.Force);

        }
        if (Input.GetKey(KeyCode.A))
        {
           
            rb.AddForce(new Vector2(-movementSpeed, 0f), ForceMode2D.Force);
            
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }

        //rb.isKinematic = touchW;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        touchW = collision.gameObject.CompareTag("Wall");
        {
            touchW = true;
        }
        //touchW = collision.gameObject.CompareTag("floor");
        //{
        //    touchW = true;
        //}
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            touchW = false;
        }
    }
}

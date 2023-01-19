using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float DriveForce = 5f;
    private Rigidbody2D rb;
    private bool airborne = true;
    private float degrees = 1f;
    int airtime = 0;
    int wheelsOnGround = 0;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Debug.Log(airborne);

        if (wheelsOnGround == 2)
        {
            airborne = false;
        }
        else
        {
            airborne = true;
        }

        if (Input.GetButton("Horizontal") && !airborne)
        {
            float moveX = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);
            
        }
        if (Input.GetAxisRaw("Vertical") == 1 && airborne)
        {
            //degrees +=0.4f;

            transform.rotation = Quaternion.Euler(Vector3.forward*(transform.localEulerAngles.z + 0.4f));

        }
        else if (Input.GetAxisRaw("Vertical") == -1 && airborne)
        {
            //degrees-=0.4f;

            transform.rotation = Quaternion.Euler(Vector3.forward * (transform.localEulerAngles.z - 0.4f));
        }

        if (Input.GetButton("Boost") && !airborne)
        {
            float moveX = Input.GetAxis("Boost");
            rb.velocity = new Vector2(moveX * moveSpeed*3, rb.velocity.y);

        }
        if (Input.GetButton("Jump"))
        {
            transform.rotation = Quaternion.Euler(Vector3.forward * 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            degrees = 0;
            wheelsOnGround++;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        wheelsOnGround--;
    }
}

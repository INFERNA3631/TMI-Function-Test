using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2D : MonoBehaviour
{
    [Header("이동")]
    [SerializeField]
    [Range(0, 10)]
    private float moveSpeed = 5.0f;

    [Header("점프")]
    [SerializeField]
    [Range(0, 10)]
    private float jumpForce = 5.0f;

    [Header("대쉬")]
    public float dashTime;
    public float dashSpeed;
    public float maxDashTime;

    private Rigidbody2D rigid2D;

    private void Awake()
    {
        rigid2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    public void Move(float x)
    {
        rigid2D.velocity = new Vector2(x * moveSpeed, rigid2D.velocity.y);
        if(x>0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if(x<0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }

    public void Jump()
    {
        rigid2D.velocity = Vector2.up * jumpForce;
    }

    public void Dash(float x)
    {
        rigid2D.velocity = new Vector2(x * dashSpeed, rigid2D.velocity.y);

        if(dashTime>=0)
        {
            dashTime -= Time.deltaTime;
            rigid2D.velocity *= (float)0.1;
        }
        else
        {
            dashTime = maxDashTime;
        }
    }
}

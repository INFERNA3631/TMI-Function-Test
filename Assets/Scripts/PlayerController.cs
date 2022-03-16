using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Movement2D movement2D;

    private void Awake()
    {
        movement2D = GetComponent<Movement2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        //�¿� �̵�
        float x = Input.GetAxisRaw("Horizontal");
        movement2D.Move(x);

        //����
        if(Input.GetKeyDown(KeyCode.Space))
        {
            movement2D.Jump();
        }

        //�뽬
        if(Input.GetKeyDown(KeyCode.X))
        {
            movement2D.Dash(x);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    //Movement
    public float moveSpeed;
    Rigidbody2D rb;
    [HideInInspector]
    public Vector2 moveDir;

    // Start is called before the first frame update
    void Start(){
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per framea
    void Update(){
        InputManagement();
    }

    void fixedUpdate(){
        Move();
    }
    void InputManagement(){
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDir = new Vector2(moveX, moveY).normalized;
    }

    void Move(){
        rb.velocity = new Vector2 (moveDir.x * moveSpeed, moveDir.y * moveSpeed);
    }
}

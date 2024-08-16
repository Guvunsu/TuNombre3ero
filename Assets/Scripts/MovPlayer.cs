using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovPlayer : MonoBehaviour
{
    [SerializeField] private float movePlayer;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rollingTimer;
    [SerializeField] private Rigidbody2D rb;
    float horizontal;
    float vertical;
    private Vector2 vector2D;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        movimiento();
    }

    void movimiento()
    {
        // caminar 
        if (movePlayer == 10){
            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");
            vector2D = new Vector2(horizontal, vertical);
            rb.AddForce(vector2D * Time.deltaTime * movePlayer);
        }
        // correr
        if (movePlayer == 25){
            Input.GetKeyDown(KeyCode.LeftShift);
        }
    }
}

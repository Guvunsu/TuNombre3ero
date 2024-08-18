using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovPlayer : MonoBehaviour {

    // jugador 
    [SerializeField] private float movePlayer;
    [SerializeField] private float moveSpeed;
    [SerializeField] private int rollingPlayer;
    [SerializeField] private double rollingTimer;

    // librerias
    [SerializeField] private Rigidbody2D rbPlayer;
    private SpriteRenderer spriteRenderer;
    private Animator animator;


    // fisicas (FixedUpdate)
    private Vector2 vector2D;
    private float horizontal;
    private float vertical;
    private float dt;


    void Start() {
        rbPlayer = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update() {
        movimiento();
    }
    private void FixedUpdate() { // movimiento jugador y fisica matematica
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        dt = Time.deltaTime;
        vector2D = new Vector2(horizontal * moveSpeed * dt, rbPlayer.velocity.x);
        vector2D = new Vector2(vertical * moveSpeed * dt, rbPlayer.velocity.y);
        rbPlayer.velocity = vector2D;
    }
    private void OnCollisionEnter2D(Collision2D collision) {//contacto con el TileMap
        if (collision.collider.CompareTag("TileMap")) {
            rbPlayer.velocity = new Vector2(transform.position.x, transform.position.y); ;
        }
        if (collision.collider.CompareTag("TileMapWater")) {
            //disableMovement(); 
            //segun yo me ayudara a que no se mueva mas el personaje y muera 
            // poner funcion de muerte y colocarlo aqui 
            //poner tal vez la funcion del menu de muerte aqui
            // poner tal vez funcion de rolling y negarlo 
        }
    }
    void movimiento() {
        // velocidad movimeinto 
        if (Input.GetKeyDown(KeyCode.LeftShift)) {
            moveSpeed = 1800f;
            //hacerlo true al correr
        } else {
            moveSpeed = 900f;
            //hacerlo false al caminar o correr
        }

        // Animator Flip Sprite
        if (vector2D.x < 0) {
            transform.localScale = Vector2.one;
            //animator.SetBool("Walk", true);
        }
        if (vector2D.x > 0) {
            transform.localScale = -1 * Vector2.one;
            // walk true
        } else {
            // idle true
        }
    }
    //  private void rolling() {
    /*

    if (Input.GetKeyDown(KeyCode.Space)
    rollingPlayer++; 
    para hacerlo la cantidad que yo quiera respetando el tiempo del rollingTimer
llamar el animator del rolling 

     */
    //}
    /*
     * agregar el bloqueo de movimiento cuando piero 
     * otro ero cuando le pongo pausa
     * */
}

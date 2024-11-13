using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    //librerias 
    [SerializeField] private Rigidbody2D rbPlayer;
    //Animation animation;
    // scripts referencias
    MovPlayer scriptMovePlayer;

    // cosas para mi Trigger
    //  bool key;
    //float dt = 3.33f;

    // cosas para mi teleport
    Transform destinationA, destinationB, player;


    // vida 
    int lifes = 6;

    void Start()
    {
        // animation = GetComponent<Animation>();
        scriptMovePlayer = GetComponent<MovPlayer>();
    }

    void Update()
    {

    }
    /*void animationsHeart(Animation animation) {
      
    }*/
    void hearts()
    { // vidas y disminuirlas
        if (lifes == 5)
        {
            lifes = -1;
            Destroy(gameObject, 1);
        }
        if (lifes == 4)
        {
            lifes = -1;
            Destroy(gameObject, 1);
        }
        if (lifes == 3)
        {
            lifes = -1;
            Destroy(gameObject, 1);
        }
        if (lifes == 2)
        {
            lifes = -1;
            Destroy(gameObject, 1);
        }
        if (lifes == 1)
        {
            lifes = -1;
            Destroy(gameObject, 1);

        }
        if (lifes == 0)
        {
            Destroy(rbPlayer);
        }
    }
    public Transform teleport() //https://www.youtube.com/watch?v=0JXVT28KCIg
    {
        if (rbPlayer)
        {
            scriptMovePlayer.disableMovement();
            //transform.position  vere estados de maquinas finitas y ponerle un cronometro a este 
        }
        return null;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    { //antes lo tenia en Exit2D

        // el OncollisionTrigger me sirve para tomar mis objetos del mapa 


        if (collision.gameObject.CompareTag("Key"))
        {
            collision.gameObject.transform.parent = gameObject.transform;
            //key = true;

        }
        if (collision.gameObject.CompareTag("ObjectsTriggers"))
        {
            teleport();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ObjectsTriggers"))
        {
            teleport();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    { //contacto con todo mi mundo
        if (collision.collider.CompareTag("ZonaDeMuerte"))
        {
            hearts();
            Destroy(gameObject.transform);
            scriptMovePlayer.disableMovement();
            //poner tal vez la funcion del menu de muerte aqui
        }
        if (collision.collider.CompareTag("TileMap"))
        {
            rbPlayer.velocity = new Vector2(transform.position.x, transform.position.y); ;
        }

        if (collision.collider.CompareTag("ObjectsOnCollision"))
        {
            Destroy(gameObject.transform);
            // probas si tengo que hacer uno especial para las vidas y aumentar este numero
        }
        else if (collision.collider.CompareTag("ObjectsOnCollision"))
        {
            gameObject.gameObject.transform.parent = gameObject.transform;
            lifes++;
        }
    }
}

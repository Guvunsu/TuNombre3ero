using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {
    [SerializeField] private Rigidbody2D rbPlayer;

    bool key;

    void Start() {

    }

    void Update() {

    }
    private void OnTriggerEnter2D(Collider2D collision) {

        // el OncollisionTrigger me sirve para tomar mis objetos del mapa 

        if (collision.gameObject.CompareTag("Key")) {
            collision.gameObject.transform.parent = gameObject.transform;
            key = true;

        }
    }
    private void OnCollisionEnter2D(Collision2D collision) {//contacto con el TileMap
        if (collision.collider.CompareTag("TileMap")) {
            rbPlayer.velocity = new Vector2(transform.position.x, transform.position.y); ;
        }
        /* if (collision.collider.CompareTag("TileMapWater")) {
             //disableMovement(); 
             //segun yo me ayudara a que no se mueva mas el personaje y muera 
             // poner funcion de muerte y colocarlo aqui 
             //poner tal vez la funcion del menu de muerte aqui
             // poner tal vez funcion de rolling y negarlo 
         }*/
    }
}

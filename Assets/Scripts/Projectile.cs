using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    bool playerProjectile = false;
    Rigidbody2D rb;

    [SerializeField] float speed;

    [SerializeField] GameData gameData;

    void Start()
    {
        if(gameObject.tag=="PlayerProjectile") playerProjectile = true;
        else if (gameObject.tag=="EnemyProjectile") playerProjectile = false;
        
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {
        if(playerProjectile){
            rb.MovePosition(rb.position + Vector2.up * speed * Time.fixedDeltaTime);
        } else {
            rb.MovePosition(rb.position + Vector2.down * speed * Time.fixedDeltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D col) {
        if(col.tag == "Destroy") {
            Destroy(gameObject);
        } else if(col.tag == "Player") {
            if(!playerProjectile) {
                gameData.playerHealthPoints -= 1;
                Destroy(gameObject);
            }
        } else if(col.tag == "Enemy") {
            if(playerProjectile) {
                col.gameObject.GetComponent<Enemy>().healthPoints -= 1;
                gameData.score += 100;
                Destroy(gameObject);
            }
        }
    }
}

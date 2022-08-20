using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 moveVector;

    [SerializeField] GameData gameData;

    [SerializeField] public float healthPoints = 1;

    [Header("Movement")]
    [Tooltip("Best with .5 or anything that won't happen at the same time as projectile shooting.")]
    [SerializeField] float moveInterval;

    [Header("Shoot Values")]
    [SerializeField] int shootIntervalMin;
    [SerializeField] int shootIntervalMax;
    [SerializeField] float shootInterval;

    [Header("Projectile")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] string projectileTag;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        moveVector = new Vector2(0f, -1.4f);

        StartCoroutine(Fire());
        StartCoroutine(Move());
    }

    void Update() {
        if(healthPoints == 0) {
            gameData.enemyCount--;
            Destroy(gameObject);
        } 
    }

    IEnumerator Fire() {
        while(true) {
            shootInterval = (float)Random.Range(shootIntervalMin, shootIntervalMax);
            yield return new WaitForSeconds(shootInterval);
            GameObject projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);
            projectile.tag = projectileTag;
        }
    }

    IEnumerator Move() {
        while(true) {
            yield return new WaitForSeconds(moveInterval);
            rb.MovePosition(rb.position + moveVector);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;

    Vector2 moveVector;

    [SerializeField] float moveSpeed;
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] string projectileTag;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {
        rb.velocity = moveVector * moveSpeed;
    }

    void OnMove(InputValue value) {
        moveVector = value.Get<Vector2>().normalized;
        moveVector = new Vector2(moveVector.x, 0f);
    }

    void OnFire(InputValue value) {
        GameObject projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);
        projectile.tag = projectileTag;
    }
}

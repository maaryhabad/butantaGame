using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float moveSpeed;
    public int damage;
    private Transform player;
    private Rigidbody2D compRigidbody;
    private SpriteRenderer sprite;
    private float move;
    private bool moving;

    private Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        compRigidbody = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float move = Input.GetAxisRaw("Horizontal");
        compRigidbody.velocity = direction * moveSpeed;
    }

    void OnTriggerEnter2D(Collider2D collision) {
        PlayerController character = collision.gameObject.GetComponent<PlayerController>();

        if (character != null) {
            character.TakeDamage(damage);
            Debug.Log(damage);
        }

    }

    public void SetDirection(Vector3 dir) {
        direction = dir;
    }
}

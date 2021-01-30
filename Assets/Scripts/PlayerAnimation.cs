using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Animator anim;
    public float speed;

    private Rigidbody2D rb;

    [Header("Attack variables")]
    public Transform AtaqueCheck;
    public float radiusAttack;
    public LayerMask Enemy;
    float timeNextAttack;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }



    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        
        if(movement.sqrMagnitude > .1f) {
            anim.SetFloat("Horizontal", movement.x);
            anim.SetFloat("Vertical", movement.y);
        }
       
       anim.SetFloat("Speed", movement.sqrMagnitude);
        // if (movement != Vector2.zero)
        // {
        //     anim.SetFloat("HorizontalIdle", movement.x);
        //     anim.SetFloat("VerticalIdle", movement.y);

        // }
    }
}


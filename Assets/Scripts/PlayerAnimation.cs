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
    

    if (timeNextAttack <= 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                anim.SetTrigger("mordeu");
                timeNextAttack = 0.00001f;
               
            }
        }

            else
        {
            timeNextAttack -= Time.deltaTime;
        }

    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed;
    public float life;
    public float damage;

    private Rigidbody2D myRigidBody;

    private bool moving;

    public float timeBetweenMove;
    private float timeBetweenMoveCounter;
    public float timeToMove;
    public float timeToMoveCounter;

    public Animator anim;
    public float speed;

    private Vector3 moveDirection;

    private PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();

        timeBetweenMoveCounter = timeBetweenMove;
        timeToMoveCounter = timeToMove;
        player = FindObjectOfType<PlayerController>();

    }

    // Update is called once per frame
    void Update()
    {
        if(moving) {
            timeToMoveCounter -= Time.deltaTime;
            myRigidBody.velocity = moveDirection;

            if(timeToMoveCounter < 0f) {
                GetComponent<Spawner>().SpawnProjetil(player.transform.position);
                Debug.Log("Atacou");
                moving = false;
                timeBetweenMoveCounter = timeBetweenMove;
            }

        } else {         
            timeBetweenMoveCounter -= Time.deltaTime;
            myRigidBody.velocity = Vector2.zero;
            if(timeBetweenMoveCounter < 0f) {
                moving = true;
                timeToMoveCounter = timeToMove;
                moveDirection = new Vector3(0f, Random.Range(-1f, 1f) * moveSpeed, 0f);
            }
        }
    }
}

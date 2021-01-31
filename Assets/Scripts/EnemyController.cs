using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed;

    public float enemyMaxHealth;
    public float enemyCurrentHealth;

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

    public float temp;
    private bool immortal;
    private Renderer mainRenderer;

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

    void OnTriggerStay2D(Collider2D other) {
        if(Input.GetButtonDown("Fire1")) {

            if(other.tag == "mordida") {
                //rodar a animação da mordida
                EnemyTakeDamage(2);
                Debug.Log("Inimigo tomou dano");
                StartCoroutine(PiscarDano());
                immortal = true;
                Invoke("ResetImortal", temp);
                Vector2 difference = transform.position - other.transform.position;
                transform.position = new Vector2(transform.position.x - difference.x, transform.position.y - difference.y);
            }
            IEnumerator PiscarDano() {
                for(int i=0; i<temp;i++) {
                    mainRenderer.enabled = true;
                    yield return new WaitForSeconds(0.1f);
                    mainRenderer.enabled = false;
                    yield return new WaitForSeconds(0.1f);
                }
            mainRenderer.enabled = true;
            }
        }
    }

    public void EnemyTakeDamage(int damage) {
        
        if(enemyCurrentHealth > 0) {
            enemyCurrentHealth -= damage;
            Debug.Log("vida do inimigo: " + enemyCurrentHealth);
            if(enemyCurrentHealth <= 0) {
                Destroy(gameObject);
            }
        }
    }

    void resetImmortal() {
        immortal = false;
    }
}

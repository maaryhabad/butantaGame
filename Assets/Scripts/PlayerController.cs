using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;
    public int stamina;
    public bool hasMaskOn;

    public int playerMaxHealth;
    public int playerCurrentHealth;

    public float waitToReload;
    public bool reloading;

    public float temp;
    private Renderer mainRenderer;

    // Start is called before the first frame update
    void Start()
    {
        mainRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f) {
            transform.Translate (new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
        }
        if(Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f) {
            transform.Translate (new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));
        }

        if (reloading) {
            waitToReload -= Time.deltaTime;
            if (waitToReload < 0) {
                var actualScene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(actualScene.name);
                playerCurrentHealth = playerMaxHealth;
            } 
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.name == "Mask") {
            hasMaskOn = true;
            other.gameObject.SetActive(false);
        }

        if(other.tag == "projetil") {
            StartCoroutine(PiscarDano());
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

    public void TakeDamage(int damage) {
        Debug.Log(reloading);

        if(playerCurrentHealth > 0) {
            playerCurrentHealth -= damage;
            Debug.Log("health: " + playerCurrentHealth);


            if(playerCurrentHealth <= 0) {
                reloading = true;
            }
        } else {
            reloading = true;
        } 
    }
}

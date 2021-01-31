﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;
    public int damage;
    public int stamina;
    public bool hasMaskOn;

    public int playerMaxHealth;
    public int playerCurrentHealth;

    public float waitToReload;
    public bool reloading;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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
    }

    public void TakeDamage(int damage) {
        Debug.Log(reloading);

        if(playerCurrentHealth <= 0) {
            reloading = true;
        } else {
            playerCurrentHealth -= damage;
            Debug.Log("health: " + playerCurrentHealth);
        }
        
    }
}

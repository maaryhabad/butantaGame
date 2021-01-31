﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNewArea : MonoBehaviour
{

    private PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.name == "Player") {
            SceneManager.LoadScene("Level2");
            player.playerCurrentHealth = player.playerMaxHealth;
        }
    }
}

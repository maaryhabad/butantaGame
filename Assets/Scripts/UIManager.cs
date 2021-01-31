using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

    public Slider healthBar;
    public PlayerController player;

   
  
    void Start()
    {
        
    }

    
    void Update()
    {
        if(healthBar != null){
        
        healthBar.maxValue = player.playerMaxHealth;
        healthBar.value = player.playerCurrentHealth;
        }
    }
}

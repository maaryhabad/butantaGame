using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoronaController : MonoBehaviour
{
    // Start is called before the first frame update

    public int damage;



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.name == "Player") {
            var player = other.gameObject.GetComponent<PlayerController>();
            if(player != null) {
                if(player.hasMaskOn) {
                    player.hasMaskOn = false;
                } else {
                    other.gameObject.SetActive(false);
                    //Destroy(other.gameObject);
                    //reiniciar a cena
                }
            }      
        }
    }

}

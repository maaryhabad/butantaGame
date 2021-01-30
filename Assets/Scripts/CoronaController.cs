using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoronaController : MonoBehaviour
{
    // Start is called before the first frame update

    public int damage;

    public float waitToReload;
    public bool reloading;
    private GameObject thePlayer;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(reloading) {
            waitToReload -= Time.deltaTime;
            if(waitToReload < 0) {

                var actualScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
                UnityEngine.SceneManagement.SceneManager.LoadScene(actualScene.name);
                thePlayer.SetActive(true);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.name == "Player") {
            var player = other.gameObject.GetComponent<PlayerController>();
            if(player != null) {
                if(player.hasMaskOn) {
                    player.hasMaskOn = false;
                } else {
                    other.gameObject.SetActive(false);
                    reloading = true;
                    thePlayer = other.gameObject;
                    //Destroy(other.gameObject);
                    //reiniciar a cena
                }
            }      
        }
    }

}

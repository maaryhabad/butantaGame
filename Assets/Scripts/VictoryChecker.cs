using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryChecker : MonoBehaviour
{

    public int enemyKills;
    private int[] killsToNextPhase = new int[] { 2, 13, 14, 8, 16 };

    private bool PegouVacina = false;

    private EnemyController enemy;

    private PlayerController player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            Scene currentScene = SceneManager.GetActiveScene();

            if (currentScene.name == "main")
            {
                SceneManager.LoadScene("Level2");
            }
            if (currentScene.name == "Level2")
            {
                enemyKills = enemy.deadEnemies;
                if (enemyKills == killsToNextPhase[0])
                {
                    SceneManager.LoadScene("Level3");
                }
            }
            if (currentScene.name == "Level3")
            {
                enemyKills = enemy.deadEnemies;
                if (enemyKills == killsToNextPhase[1])
                {
                    SceneManager.LoadScene("Level4");
                }
            }
            if (currentScene.name == "Level4")
            {
                enemyKills = enemy.deadEnemies;
                if (enemyKills == killsToNextPhase[2])
                {
                    SceneManager.LoadScene("Level5");
                }
            }
            if (currentScene.name == "Level5")
            {
                enemyKills = enemy.deadEnemies;
                if (enemyKills == killsToNextPhase[3])
                {
                    SceneManager.LoadScene("Level6");
                }

            }
            if (currentScene.name == "Level6")
            {
                enemyKills = enemy.deadEnemies;
                if (enemyKills == killsToNextPhase[4])
                {
                    SceneManager.LoadScene("Level7");

                }
                if (currentScene.name == "Level7")
                {

                    if (PegouVacina)
                    {
                        SceneManager.LoadScene("Win");

                    }
                    player.playerCurrentHealth = player.playerMaxHealth;
                }
            }

        }
    }
}
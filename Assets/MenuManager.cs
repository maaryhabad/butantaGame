using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
     public void Iniciar(){

        SceneManager.LoadScene("main");

    }

    public void Sair(){

        Application.Quit();

    }
}

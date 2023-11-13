    using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static int pontuacao = 0;
    public static string ganhou;
    public static int Vida = 10;
    public static int VidaEnemy = 2;

    // public static int porcentagem = 0;

    void Update(){
        if(Input.GetKeyDown(KeyCode.P) && Input.GetKeyDown(KeyCode.I) && Input.GetKeyDown(KeyCode.O)){
            SceneManager.LoadScene("Começo");
        }
        // if(Input.GetKeyDown(KeyCode.O)){
        //     SceneManager.LoadScene("Lvl2");
        // }
        // if(Input.GetKeyDown(KeyCode.I)){
        //     SceneManager.LoadScene("RealLevel");
        // }
        // if(Input.GetKeyDown(KeyCode.L)){
        //     SceneManager.LoadScene("mundoTest");
        // }
        // if(Input.GetKeyDown(KeyCode.K)){
        //     SceneManager.LoadScene("InfSpace");
        // }
        

    }
    
}

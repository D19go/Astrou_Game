using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Manual: MonoBehaviour
{
    public Button botaoJogar;
    public Button botaoSair;
    public Button botaoManual;
    public Button botaovoltar;

    void Start()
    {
        botaoJogar.onClick.AddListener(() =>{
            SceneManager.LoadScene("Começo");
        });
        
        botaoManual.onClick.AddListener(() =>{
            SceneManager.LoadScene("Instruções");
        });
        botaoSair.onClick.AddListener(() =>{
            SceneManager.LoadScene("Menu");
        });
        botaovoltar.onClick.AddListener(() =>{
            SceneManager.LoadScene("Menu");
        });
    }

}

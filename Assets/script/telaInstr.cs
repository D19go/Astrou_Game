using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class telaInstr : MonoBehaviour
{
    public Button botaoSair;


    void Start()
    {
        botaoSair.onClick.AddListener(() =>{
            SceneManager.LoadScene("Menu");
        });
    }
}

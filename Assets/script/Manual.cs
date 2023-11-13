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
    int indiceCenaAtual = SceneManager.GetActiveScene().buildIndex;

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
    }

}

public class TrocarCena : MonoBehaviour
{
    // Chamado quando o bot�o � clicado ou outro evento de desencadeamento ocorre
    public void PularParaProximaCena()
    {
        // Obt�m o �ndice da cena atual
        int indiceCenaAtual = SceneManager.GetActiveScene().buildIndex;

        // Pula para a pr�xima cena (aumenta o �ndice em 1)
        SceneManager.LoadScene(indiceCenaAtual + 1);
    }
}

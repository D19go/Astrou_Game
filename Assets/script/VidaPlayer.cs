using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VidaPlayer : MonoBehaviour
{
    public TextMeshProUGUI vidaT;
    public SceneManager cenaAtual;
    public int vida = 10;
    // Start is called before the first frame update
    public void TomaToma(int dano)
    {
        vida -= dano;
        if(vida <= 0){
            
            vidaT.text = vida.ToString();
            SceneManager.LoadScene("Planet1");
            Destroy(gameObject);
        }
        if (vidaT != null)
        {
            vidaT.text = " " +vida.ToString();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

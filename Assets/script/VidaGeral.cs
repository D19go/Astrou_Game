using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VidaGeral : MonoBehaviour
{
    public TextMeshProUGUI vidaT;
    public SceneManager cenaAtual;
    public int vida = 10;
    // Start is called before the first frame update
    public void TomaToma(int dano)
    {
        vida -= dano;
        if(vida <= 0){
            
          
            
            Destroy(gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

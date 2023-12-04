using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;    
using UnityEngine;
using UnityEngine.SceneManagement;

public class VidaPlayer : MonoBehaviour
{
    [SerializeField] private bool escudo = false;
    public TextMeshProUGUI vidaT;
    public float vida = 10;
    // Start is called before the first frame update
    public void TomaToma(float dano)
    {
        if(escudo)
            return;        
        

        vida -= dano;
        if(vida <= 0){
            
            vidaT.text = " " +vida.ToString();
            SceneManager.LoadScene("Começo");
            Destroy(gameObject);
        }
        if (vidaT != null)
        {
            vidaT.text = " " +vida.ToString();
        }

    }

    public void EscAtivo(bool sim){
        escudo = sim;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

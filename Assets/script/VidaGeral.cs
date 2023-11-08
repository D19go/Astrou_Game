using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaGeral : MonoBehaviour
{
    public int vida = 10;
    // Start is called before the first frame update
    public void TomaToma(int dano)
    {
        Debug.Log("tomou");
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

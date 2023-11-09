using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LigaSpanw : MonoBehaviour
{
    public int vida = 10;
    public int menos1 = 2;

    public GameObject Spawner;
    void Start()
    {
        
    }
    
    // Start is called before the first frame update
    public void TomaToma2(int dano)
    {
        Debug.Log("tomou");
        vida -= dano;
        if(vida <= 0){
            Spawner.GetComponent<spanw>().Quantos(menos1);
            Destroy(gameObject);
        }

    }
}

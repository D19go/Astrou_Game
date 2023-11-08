using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemysimples : MonoBehaviour
{
    public int vida = 10;
    public int dano = 10;
        // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        vida -= dano;
        if (vida <= 0){
            Destroy(gameObject);
        }
    }
}

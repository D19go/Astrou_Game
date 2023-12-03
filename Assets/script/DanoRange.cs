using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanoRange : MonoBehaviour
{
    [SerializeField] private int dano;
   void OnCollisionEnter(Collision colidiu)
    {    
        if(colidiu.gameObject.tag == "Player"){
            colidiu.gameObject.GetComponent<VidaPlayer>().TomaToma(dano);
            Destroy(gameObject);
        
        }  
        Destroy(gameObject);
    }
}

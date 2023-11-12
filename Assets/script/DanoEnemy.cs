using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanoEnemy : MonoBehaviour
{
     public int dano = 10;
    // void OnTriggerEnter(Collider collide)
    void OnCollisionStay(Collision collide)
    {   
        
        if(collide.gameObject.tag == "Player"){
            collide.gameObject.GetComponent<VidaPlayer>().TomaToma(dano);
        }
        if(collide.gameObject.tag == "ArvoreMae"){
            collide.gameObject.GetComponent<VidaPlayer>().TomaToma(dano);
        }
    }
}

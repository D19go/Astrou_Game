using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanoEnemy : MonoBehaviour
{
     public int dano = 10;
    void OnTriggerEnter(Collider collide)
    {   
        
        if(collide.gameObject.tag == "Player"){
            collide.gameObject.GetComponent<VidaPlayer>().Vida_Manager(dano);
        }
        if(collide.gameObject.tag == "ArvoreMae"){
            collide.gameObject.GetComponent<VidaPlayer>().Vida_Manager(dano);
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanoGeral : MonoBehaviour
{
    public int dano = 10;
    void OnTriggerEnter(Collider collide)
    {
        Debug.Log("foi");
        if(collide.gameObject.tag == "EnemyIA"){
            collide.GetComponent<VidaGeral>().TomaToma(dano);
        }
        if(collide.gameObject.tag == "Enemy"){
            Debug.Log("asds");
            collide.GetComponent<VidaGeral>().TomaToma(dano);
        }
        if(collide.gameObject.tag == "Enemy2"){
            collide.GetComponent<VidaGeral>().TomaToma(dano);
        }
    }
}

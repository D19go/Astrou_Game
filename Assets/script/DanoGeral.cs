using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanoGeral : MonoBehaviour
{
    public int dano = 10;
    // void OnTriggerEnter(Collider collide)
    void OnCollisionEnter(Collision collide)
    {   
        
        if(collide.gameObject.tag == "EnemyPurple"){
            collide.gameObject.GetComponent<VidaGeral>().TomaToma(dano);
             Destroy(gameObject);
        }
        if(collide.gameObject.tag == "EnemyRed"){
            collide.gameObject.GetComponent<LigaSpanw>().TomaToma2(dano);
             Destroy(gameObject);
        }
        if(collide.gameObject.tag == "EnemyGreen"){
            collide.gameObject.GetComponent<LigaSpanw>().TomaToma2(dano);
             Destroy(gameObject);
        }
        if(collide.gameObject.tag == "BossEnemy"){
            collide.gameObject.GetComponent<VidaGeral>().TomaToma(dano);
             Destroy(gameObject);
        }
    }
}

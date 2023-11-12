using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanoGeral : MonoBehaviour
{
    void Start(){
        F();
    }
    public int dano = 10;
    // void OnTriggerEnter(Collider collide)
    void OnCollisionEnter(Collision collide)
    {   
        
        if(collide.gameObject.tag == "EnemyPurple"){
            collide.gameObject.GetComponent<LigaSpanw>().TomaToma2(dano);
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
        // if(collide.gameObject.tag == "ArvoreMae"){
        //     collide.gameObject.GetComponent<VidaPlayer>().TomaToma(dano);
        //      Destroy(gameObject);

        // }
        if(collide.gameObject.tag == "piso"){
            Destroy(gameObject);

        }
        if(collide.gameObject.tag == "TestOBJ"){
            // Destroy(gameObject);
            Debug.Log("acertou");
        }
        F();
    }

    IEnumerator F(){
    
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}

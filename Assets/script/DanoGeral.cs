using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanoGeral : MonoBehaviour
{
    void Start(){
    }
    public int dano = 10;
    void OnTriggerEnter(Collider colidiu){
        if(colidiu.gameObject.tag == "Enemy"){
            colidiu.gameObject.GetComponent<LigaSpanw>().TomaToma2(dano);
             Destroy(gameObject);
        
        }  

        if(colidiu.gameObject.tag == "TestOBJ"){
            // Destroy(gameObject);
            Debug.Log("acertou");
        }
    }
    void OnCollisionEnter(Collision colidiu)
    {   
        
        if(colidiu.gameObject.tag == "Enemy"){
            colidiu.gameObject.GetComponent<LigaSpanw>().TomaToma2(dano);
             Destroy(gameObject);
        
        }   
        // if(colidiu.gameObject.tag == "EnemyRed"){
        //     colidiu.gameObject.GetComponent<LigaSpanw>().TomaToma2(dano);
        //      Destroy(gameObject);

        // }
        // if(colidiu.gameObject.tag == "EnemyGreen"){
        //     colidiu.gameObject.GetComponent<LigaSpanw>().TomaToma2(dano);
        //      Destroy(gameObject);

        // }
        // if(colidiu.gameObject.tag == "BossEnemy"){
        //     colidiu.gameObject.GetComponent<VidaGeral>().TomaToma(dano);
        //      Destroy(gameObject);

        // }
        // if(colidiu.gameObject.tag == "ArvoreMae"){
        //     colidiu.gameObject.GetComponent<VidaPlayer>().TomaToma(dano);
        //      Destroy(gameObject);

        // }
        if(colidiu.gameObject.tag == "piso"){
            Destroy(gameObject);

        }
        if(colidiu.gameObject.tag == "TestOBJ"){
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanoGeral : MonoBehaviour
{
    
    void Start(){
        StartCoroutine(zaz());
    }

    public int dano = 10;

    void OnCollisionEnter(Collision colidiu)
    {

        Debug.Log(GameObject.Find("oiasdijasd").transform.GetChild(123123));
        
        if(colidiu.gameObject.tag == "Enemy"){
            colidiu.gameObject.GetComponent<LigaSpanw>().TomaToma2(dano);
            Destroy(gameObject);
        }   
        if(colidiu.gameObject.tag == "EnemyV2"){
            colidiu.gameObject.GetComponent<LigaSpanw>().TomaToma2(dano);
            Destroy(gameObject);

        }
        // if(colidiu.gameObject.tag == "EnemyGreen"){
        //     colidiu.gameObject.GetComponent<LigaSpanw>().TomaToma2(dano);
        //     Destroy(gameObject);

        // }
        if(colidiu.gameObject.tag == "BossEnemy"){
            colidiu.gameObject.GetComponent<VidaGeral>().TomaToma(dano);
            Destroy(gameObject);

        }
        // if(colidiu.gameObject.tag == "ArvoreMae"){
        //     colidiu.gameObject.GetComponent<VidaPlayer>().TomaToma(dano);
        //     Destroy(gameObject);

        // }
        if(colidiu.gameObject.tag == "piso"){
            Destroy(gameObject);

        }
        if(colidiu.gameObject.tag == "TestOBJ"){
            Debug.Log("acertou");
        }
        Destroy(gameObject);
    }

    IEnumerator zaz(){
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}

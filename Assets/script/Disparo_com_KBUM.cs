using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Disparo_com_KBUM : MonoBehaviour
{
    public GameObject Area;
    public int dano;
    public bool sim = true;
    bool ok = false;
    public Rigidbody rb;
    // --------------------------//
    public float forcaExplo = 200;
    public float raioExplo = 10;
    //--------------------------//
    // Start is called before the first frame update
    void Start(){
        rb = GetComponent<Rigidbody>();
    }
    
    void OnCollisionEnter(Collision colidiu){
        GetComponent<MeshRenderer>().enabled = false;
        StartCoroutine(destroi());
        if(colidiu.gameObject.tag == "Enemy"){
            colidiu.gameObject.GetComponent<LigaSpanw>().TomaToma2(dano);
            colidiu.gameObject.GetComponent<LigaSpanw>().Explosioon();
            rb.isKinematic = true;
            rb.AddExplosionForce(forcaExplo, transform.position, raioExplo);
            Area.transform.localScale = new Vector3 (raioExplo * 3,raioExplo,raioExplo);
            
        }   
        if(colidiu.gameObject.tag == "EnemyV2"){
            colidiu.gameObject.GetComponent<VidaGeral>().TomaToma(dano);
            colidiu.gameObject.GetComponent<VidaGeral>().Explosioon();
            rb.isKinematic = true;
            rb.AddExplosionForce(forcaExplo, transform.position, raioExplo);
            Area.transform.localScale = new Vector3 (raioExplo * 3,raioExplo,raioExplo);
        }
        rb.AddExplosionForce(forcaExplo, transform.position, raioExplo);
        Area.transform.localScale = new Vector3 (raioExplo,raioExplo,raioExplo);
        rb.isKinematic = true;
    }
    IEnumerator destroi(){
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}

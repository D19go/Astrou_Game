using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtkRange : MonoBehaviour
{
    [SerializeField] private int dano;
    [SerializeField] private GameObject dardo;
    [SerializeField] private int Forca;
    [SerializeField] private Animator anim;
    private GameObject alvo;

    private Vector3 PlayerAlvo;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            anim.SetTrigger("SPEELLL");
            alvo = other.gameObject;
        }
    }

    public void atk()
    {
        GameObject dardo_ = Instantiate(dardo, transform.position, Quaternion.identity);
        PlayerAlvo = (alvo.transform.position - transform.position).normalized;

        Quaternion rotacao = Quaternion.LookRotation(PlayerAlvo);
        dardo_.transform.rotation = rotacao * Quaternion.Euler(90, 0, 0);

        dardo_.GetComponent<Rigidbody>().AddForce(PlayerAlvo * Forca);
    }
    

    
   void OnCollisionEnter(Collision colidiu)
    {   
        
        if(colidiu.gameObject.tag == "Player"){
            colidiu.gameObject.GetComponent<VidaPlayer>().TomaToma(dano);
            Destroy(gameObject);
        
        }  
    }
}

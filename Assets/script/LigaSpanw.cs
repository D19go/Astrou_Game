using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class LigaSpanw : MonoBehaviour
{
    public int vida = 10;
    Rigidbody rb;
    public int menos1 = 2;
    bool ch = false;
    DropItem drop;
    NavMeshAgent IAnav;
    Animator ani;
    FocoPlayer fp;
    FocoArvore fa;
    public GameObject Spawner;
    void Start()
    {
        ani = GetComponent<Animator>();
        IAnav = GetComponent<NavMeshAgent>();
        drop = GetComponent<DropItem>();
        Spawner = GameObject.Find("Spawner");
        rb = GetComponent<Rigidbody>();
        if(TryGetComponent<FocoArvore>( out FocoArvore f))
        {
            fa = GetComponent<FocoArvore>();
            fp = null;
        }
        else
        {
            fp = GetComponent<FocoPlayer>();
            fa = null;
        }
    }

    public void chamas(int i){
        vida -= i;
        if(vida <= 0){
            Spawner.GetComponent<spanw>().Quantos(menos1);
        }
    }
    
    // Start is called before the first frame update
    public void TomaToma2(int dano)
    {
        vida -= dano;
        if(vida <= 0 && !ch)
        {
            //StartCoroutine(drop.dropRate());
            StartCoroutine(Morto());
            Spawner.GetComponent<spanw>().Quantos(menos1);
            ch = true;
               
        }

    }

    IEnumerator Morto(){
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
        
    }

    public void Explosioon(){
        IAnav.enabled = false;
        if (TryGetComponent<FocoArvore>(out FocoArvore f))
        {
            GetComponent<FocoArvore>().enabled = false;
        }
        else
        {
            GetComponent<FocoPlayer>().enabled = false;
            
        }
        ani.enabled = false;
    }
    void OnCollisionEnter(Collision coli){
        if(coli.gameObject.tag == "piso"){
            IAnav.enabled = true;
            if (fp == null)
            {
                fa.enabled = true;
            }
            else
            {
                fp.enabled = true;
            }
            ani.enabled = true;
        }
    }
}

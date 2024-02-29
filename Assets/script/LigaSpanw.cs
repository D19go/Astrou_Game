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
    
    DropItem drop;
    NavMeshAgent IAnav;
    Animator ani;
    public GameObject Spawner;
    void Start()
    {
        ani = GetComponent<Animator>();
        IAnav = GetComponent<NavMeshAgent>();
        drop = GetComponent<DropItem>();
        Spawner = GameObject.Find("Spawner");
        rb = GetComponent<Rigidbody>();
    }

    public void chamas(int i){
        Debug.Log("tomou2");
        vida -= i;
        if(vida <= 0){
            Spawner.GetComponent<spanw>().Quantos(menos1);
        }
    }
    
    // Start is called before the first frame update
    public void TomaToma2(int dano)
    {
        Debug.Log("tomou");
        vida -= dano;
        if(vida <= 0){
            Spawner.GetComponent<spanw>().Quantos(menos1);
            StartCoroutine(Morto());
            StartCoroutine(drop.dropRate());
        }

    }

    IEnumerator Morto(){
        yield return new WaitForSeconds(0.5f);
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<FocoPlayer>().enabled = false;
    }

    public void Explosioon(){
        IAnav.enabled = false;
        GetComponent<FocoPlayer>().enabled = false;
        ani.enabled = false;
    }
    void OnCollisionEnter(Collision coli){
        if(coli.gameObject.tag == "piso"){
            IAnav.enabled = true;
            GetComponent<FocoPlayer>().enabled = true;
            ani.enabled = true;
        }
    }
}

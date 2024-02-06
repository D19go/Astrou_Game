using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LigaSpanw : MonoBehaviour
{
    public int vida = 10;
    public int menos1 = 2;
    DropItem drop;

    public GameObject Spawner;
    void Start()
    {
        drop = GetComponent<DropItem>();
        Spawner = GameObject.Find("Spawner");
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
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class VidaGeral : MonoBehaviour
{
    public SceneManager cenaAtual;
    public int vida = 10;
    NavMeshAgent IAnav;
    void Start()
    {
        IAnav = GetComponent<NavMeshAgent>();
    }


    // Start is called before the first frame update
    public void TomaToma(int dano)
    {
        vida -= dano;
        if(vida <= 0){
            Destroy(gameObject);
        }

    }

    public void Explosioon(){
        IAnav.enabled = false;
        GetComponent<FocoPlayer>().enabled = false;
    }
    void OnCollisionEnter(Collision coli){
        if(coli.gameObject.tag == "piso"){
            IAnav.enabled = true;
            GetComponent<FocoPlayer>().enabled = true;
        }
    }
}

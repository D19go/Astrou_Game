using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerseguePlayer : MonoBehaviour
{
    public float velocidade = 2f;
    private  Rigidbody BadBugRG;
    public GameObject Player;
    public int dano = 10;
  
    void Start()
    {
        BadBugRG = GetComponent<Rigidbody>();
        BadBugRG.freezeRotation = true;
        Player = GameObject.FindWithTag("ArvoreMae");
    }

    // Update is called once per frame
    void Update()
    {
        BadBugRG.AddForce((Player.transform.position - transform.position).normalized * velocidade);        
    }

    void OnColliderEnter(Collider colisao){
        if(colisao.gameObject.tag == "ArvoreMae"){
            colisao.GetComponent<VidaGeral>().TomaToma(dano);
        }
    }
}
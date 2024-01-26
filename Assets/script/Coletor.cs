using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coletor : MonoBehaviour
{
    void OnTriggerEnter(Collider collider){
        if(collider.gameObject.tag == "PeRadio1"){
            GameObject.Find("Canvas").GetComponent<MissoesP1>().pegaPedras();                  
            Destroy(transform.gameObject);
        }
        if(collider.gameObject.name == "chave"){
            GameObject.Find("Canvas").GetComponent<Missoes>().pegaChave(); 
            Debug.Log("tocou");
        }
        if(collider.gameObject.tag == "combustivel"){
            GameObject.Find("Canvas").GetComponent<Missoes>().pegaGalao(); 
            
            Debug.Log("tocou");
        }
    }

}

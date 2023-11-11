using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moeda : MonoBehaviour
{
    void OnTriggerEnter(Collider collider){
        GameObject.Find("Canvas").GetComponent<MissoesP1>().pegaPedras();                  
        Destroy(transform.gameObject);
    }
}

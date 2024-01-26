using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coletavel : MonoBehaviour
{
    void OnTriggerEnter(Collider Colidiu){
        if(Colidiu.gameObject.tag == "Player"){
            Destroy(gameObject);
        }
    }
}

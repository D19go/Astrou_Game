using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampoDetectboss : MonoBehaviour
{
    [SerializeField] private Animator bezoro;

    void OnTriggerStay(Collider colisao){
        if(colisao.gameObject.tag == "Player"){
            bezoro.SetTrigger("Smash Attack");
        }

        if(colisao.gameObject.tag == "ArvoreMae"){
            bezoro.SetTrigger("Smash Attack");
        }
    }

    
}
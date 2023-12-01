using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampoDetect : MonoBehaviour
{
    [SerializeField] private Animator bezoro;

    void OnTriggerStay(Collider colisao){
        if(colisao.gameObject.tag == "Player"){
            bezoro.SetTrigger("Stab Attack");
        }
    }

    
}
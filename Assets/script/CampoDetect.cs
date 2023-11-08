using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampoDetect : MonoBehaviour
{
    // public Animator bezoro;
    public float velo = 5f;

    void OnTriggerStay(Collider colisao){
        if(colisao.gameObject.tag == "Player"){
            Vector3 Alvo = colisao.transform.position - transform.parent.position;
            Alvo.Normalize();
            transform.parent.position += Alvo * velo * Time.deltaTime;
            transform.parent.LookAt(colisao.transform);
        }
    }

    
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chamas : MonoBehaviour
{
    [SerializeField] private int dano = 10;
     void OnTriggerStay(Collider EmChamas)
    {
        if(EmChamas.gameObject.tag == "EnemyRed"){
            gameObject.GetComponent<VidaGeral>().TomaToma(dano);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TpOBJ : MonoBehaviour
{
    public GameObject p;
    public GameObject teleporte;
    public Transform telePorte;
    private Vector3 TeleportePosition;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider colidiu)
    {
        if(colidiu.gameObject.tag == "Player"){
            Debug.Log("ocorreu1");
            TeleportePosition = telePorte.position;
            Debug.Log("ocorreu2");
            p.transform.position = TeleportePosition;
            Debug.Log("ocorreu3");
        }
    }
    void Update()
    {
        
    }
}

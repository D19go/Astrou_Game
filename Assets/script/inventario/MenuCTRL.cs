using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCTRL : MonoBehaviour
{
    [SerializeField] private GameObject Painel;
    bool PainelAct;
    void Start()
    {
        
    }

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab)){
            PainelAct = !PainelAct;
            Painel.SetActive(PainelAct);
        }
        if(PainelAct){
            Cursor.lockState = CursorLockMode.None;
        }
    }
}

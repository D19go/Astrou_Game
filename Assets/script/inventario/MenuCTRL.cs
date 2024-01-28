using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuCTRL : MonoBehaviour
{
    [SerializeField] private GameObject Painel;
    bool PainelAct;
    public Text ItemText;
    void Start()
    {
        ItemText.text = null;
    }

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab)){
            PainelAct = !PainelAct;
            Painel.SetActive(PainelAct);
        }
        if(PainelAct){
            Cursor.lockState = CursorLockMode.None;
        }else if(!PainelAct){
            Cursor.lockState = CursorLockMode.Locked;

        }
    }
}

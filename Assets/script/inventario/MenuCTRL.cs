using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class MenuCTRL : MonoBehaviour
{
    [SerializeField] private GameObject Painel;
    bool PainelAct;
    public Text ItemText;
    public List<Button> TelaInv;
    public InventarioCTRL invPlayer;
    public Bau_Inv Bau_Slots;
    void Start()
    {
        Bau_Slots = FindAnyObjectByType<Bau_Inv>();
        invPlayer = FindAnyObjectByType<InventarioCTRL>();
        ItemText.text = null;
    }

    
    void Update()
    {
        /*if(Input.GetKeyDown(KeyCode.Tab)){
            PainelAct = !PainelAct;
            Painel.SetActive(PainelAct);
        }*/

        if(PainelAct){
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }else if(!PainelAct){
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
    public void OnSlotClick(string nome){
        Debug.Log("chamou o click");  
        for(int i = 0; i < TelaInv.Count; i++){
            if(TelaInv[i].name == nome){
                if(invPlayer.slots3D[i].sprite != null){
                    
                    Debug.Log("dentro do if do for no click"); 
                    Bau_Slots.bauTrade(i,i);
                    Bau_Slots.mouse = true;
                    invPlayer.slotsAmount[i]--;
                    if(invPlayer.slotsAmount[i] <= 0){
                        invPlayer.slots[i] = null;
                        invPlayer.slots3D = null;
                    }
                    break;
                } 
            }

        }
        
    }
    public void bau(){
        PainelAct =! PainelAct;
    }   
}

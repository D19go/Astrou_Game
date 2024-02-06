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
        if(Input.GetKeyDown(KeyCode.Tab)){
            PainelAct = !PainelAct;
            Painel.SetActive(PainelAct);
        }

        if(PainelAct){
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }else if(!PainelAct){
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        for (int i = 0; i < TelaInv.Count; i++)
                {
                    int slotIndex = i;  // Armazena o índice para evitar o problema do closure
                    TelaInv[i].onClick.AddListener(() => OnSlotClick(slotIndex));
                }
    }
    void OnSlotClick(int slotIndex){
        int slotss = slotIndex;
        int slotsAmounti = slotIndex;
        Bau_Slots.bauTrade(slotss, slotsAmounti);
    }
    public void bau(){
        PainelAct =! PainelAct;
    }   
}

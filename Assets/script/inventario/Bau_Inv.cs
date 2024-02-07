using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Bau_Inv : MonoBehaviour
{
    public List<Objectos> slots_Bau;
    public List<Image> slots3D_Bau;
    public List<int> slotsAmount_Bau; 
    public InventarioCTRL invPlayer;
    [SerializeField] private TextMeshProUGUI nome;
    [SerializeField] private TextMeshProUGUI descricao;
    public bool mouse = false;
    public List<Button> TelaInv;

    // Start is called before the first frame update
    void Start()
    {
        invPlayer = FindAnyObjectByType<InventarioCTRL>();   
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < TelaInv.Count; i++)
        {
            int slotIndex = i;  // Armazena o índice para evitar o problema do closure
            TelaInv[i].onClick.AddListener(() => OnSlotClick(slotIndex));
        }
        
    }

    void OnSlotClick(int slotIndex){
        nome.text = slots_Bau[slotIndex].ItemName;
        descricao.text = slots_Bau[slotIndex].Description;
    }

    public void bauTrade(int Slots, int slotsAmount){     
        Debug.Log("chamou o bau trade");  
        for(int i = 0; i < slots_Bau.Count; i++){
            Debug.Log("for do bautrade");  
            if(slots3D_Bau[i].sprite == null){
                Debug.Log("if do for no bautrde");
                slots_Bau[i] = invPlayer.slots[Slots];
                slotsAmount_Bau[i] = invPlayer.slotsAmount[slotsAmount];
                slots3D_Bau[i].sprite = invPlayer.slots[Slots].Item3D;
                mouse = false;
                break;
            }
            
        }
        
        
    }
    
}

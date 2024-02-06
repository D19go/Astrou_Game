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
    bool mouse = false;
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
        
        slots_Bau[Slots] = invPlayer.slots[Slots];
        slotsAmount_Bau[Slots] = invPlayer.slotsAmount[slotsAmount];
        slots3D_Bau[Slots].sprite = invPlayer.slots[Slots].Item3D;
    }
    
}

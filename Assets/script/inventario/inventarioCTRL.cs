using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventarioCTRL : MonoBehaviour
{
    public List<Objectos> slots;
    public List<Image> slots3D;
    public List<int> slotsAmount;
    [SerializeField] private int distancia = 3;
    [SerializeField] private Camera cam1;
    [SerializeField] private Missoes M0;
    [SerializeField] private MissoesP1 M1;  
    
    
    [SerializeField] private Bau_Inv Bauzinho;
    private MenuCTRL IController;
    public List<Image> Barra_Inv;
    

    void Start(){
        
        M0 = FindAnyObjectByType<Missoes>();
        M1 = FindAnyObjectByType<MissoesP1>();
        IController = FindAnyObjectByType<MenuCTRL>();
        cam1 = Camera.main;
    }
    
    void Update(){
        
        cam1 = Camera.main;
        RaycastHit hit;
        Ray ray = cam1.ScreenPointToRay(new Vector3(Screen.width/2, Screen.height/2));
            if(Physics.Raycast(ray, out hit, distancia)){
                if(hit.collider.tag == "objeto"){
                    IController.ItemText.text = "pressione (E) para coletar " +  hit.transform.GetComponent<ObjectType>().objectType.name;
                    if(Input.GetKeyDown(KeyCode.E)){
                        for(int i =0; i <= slots.Count; i++){
                            if(slots[i] == null || slots[i].name == hit.transform.GetComponent<ObjectType>().objectType.name){
                                slots[i] = hit.transform.GetComponent<ObjectType>().objectType;
                                slotsAmount[i]++;
                                slots3D[i].sprite = slots[i].Item3D;
                                if(i < Barra_Inv.Count && Barra_Inv[i].sprite == null){
                                    Barra_Inv[i].sprite = slots[i].Item3D;
                                }
                               
                                Destroy(hit.transform.gameObject);
                                break;
                            }
                        }
                        
                    }
                }
            }else{
                IController.ItemText.text = null;
            }


    }

    

    

}


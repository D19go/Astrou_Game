using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class InventarioCTRL : MonoBehaviour
{
    [SerializeField] public Objects[] slots;
    [SerializeField] private Image[] slotsImage;
    [SerializeField] private int[] slotsAmount; 
    [SerializeField]private int distancia = 3;
    [SerializeField]private Camera cam1;
    private MissoesP1 M1;

    private MenuCTRL IController;

    void Start(){
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
                IController.ItemText.text = "perssione (E) para coletar " +  hit.transform.GetComponent<ObjectType>().objectType.name;
                if(Input.GetKeyDown(KeyCode.E)){
                    for(int i =0; i < slots.Length; i++){
                        if(slots[i] == null || slots[i].name == hit.transform.GetComponent<ObjectType>().objectType.name){
                            slots[i] = hit.transform.GetComponent<ObjectType>().objectType;
                            slotsAmount[i]++;
                            slotsImage[i].sprite = slots[i].ItemSprite;

                            Destroy(hit.transform.gameObject);
                            break;
                        }
                    }
                }
            }else if(hit.collider.tag != "objeto" || hit.collider.tag == null){
                IController.ItemText.text = null;
            }
        }
    }

    

}


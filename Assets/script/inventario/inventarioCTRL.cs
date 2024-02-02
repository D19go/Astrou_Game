using UnityEngine;
using UnityEngine.UI;

public class InventarioCTRL : MonoBehaviour
{
    [SerializeField] public Objects[] slots;
    [SerializeField] public GameObject[] slots3D;
    [SerializeField] private int[] slotsAmount; 
    [SerializeField] private int distancia = 3;
    [SerializeField] private Camera cam1;
    [SerializeField] private Missoes M0;
    [SerializeField] private MissoesP1 M1;  
    int loop;
    private MenuCTRL IController;

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
                IController.ItemText.text = "perssione (E) para coletar " +  hit.transform.GetComponent<ObjectType>().objectType.name;
                if(Input.GetKeyDown(KeyCode.E)){
                    for(int i =0; i <= slots.Length; i++){
                        if(slots[i] == null || slots[i].name == hit.transform.GetComponent<ObjectType>().objectType.name){
                            slots[i] = hit.transform.GetComponent<ObjectType>().objectType;
                            slotsAmount[i]++;
                            slots3D[i] = slots[i].Item3D;
                            M0.GetComponent<Missoes>().checarMissoes();
                            // M1.GetComponent<MissoesP1>().ListaMissoes();
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


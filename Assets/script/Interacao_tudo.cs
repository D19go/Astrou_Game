using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interacao_tudo : MonoBehaviour
{

    public int carGas;
    [SerializeField] private int distancia = 3;
    [SerializeField] private Camera cam1;
    public bool reabastece = false;
    private MenuCTRL IController;
    private InventarioCTRL inv;
    private Bau_Inv bau;
    [SerializeField] GameObject Bau_Canvas;
    bool open_close = false;
    int loop;

    // Start is called before the first frame update
    void Start()
    {
        bau = FindAnyObjectByType<Bau_Inv>();
        cam1 = Camera.main;
        IController = FindAnyObjectByType<MenuCTRL>();
        inv = FindAnyObjectByType<InventarioCTRL>(); 
    }

    // Update is called once per frame
    void Update()
    {
        cam1 = Camera.main;
        RaycastHit hit;
        Ray ray = cam1.ScreenPointToRay(new Vector3(Screen.width/2, Screen.height/2));
        if(Physics.Raycast(ray, out hit, distancia)){
            if(hit.collider.tag == "Car"){
                
                IController.ItemText.text = "pressione (E) para abastercer o carro ";
                for(int i =0; i < inv.slots.Count; i++){
                    if(inv.slots[i].ItemName == "Galão de Combustivel"){
                        
                        reabastece = true;
                        loop = i;
                        break;
                    }
                }

                if(Input.GetKeyDown(KeyCode.E)){
                    if(reabastece){
                        hit.collider.GetComponentInParent<CarController>().gasolina();
                        inv.slotsAmount[loop]--;
                        ToastNotification.Show("Carro abastecido \n Nivel do combustivel: " + carGas);
                        if(inv.slotsAmount[loop] == 0){
                            inv.slots[loop] = null;
                            inv.slots3D[loop].sprite = null;
                            inv.Barra_Inv[loop].sprite = null;
                        }
                    }
                }
            }else if(hit.collider.tag != "Car" || hit.collider.tag == null){
                reabastece = false;
                loop = 0;
            }
        }else{
                IController.ItemText.text = null;
        }

        
//--------------------------------------------------------------------------------------------------

        if(Physics.Raycast(ray, out hit, distancia)){
            if(hit.collider.tag == "Armazenamento"){
                IController.ItemText.text = "pressione (E) para abrir o Baú ";
                if(Input.GetKeyDown(KeyCode.E)){
                    open_close =! open_close;
                    Bau_Canvas.SetActive(open_close);
                    IController.bau();
                }
            }
        }else{
                IController.ItemText.text = null;
        }
    }
}

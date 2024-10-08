using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interacao_tudo : MonoBehaviour
{

    public int carGas;
    [SerializeField] private int distancia = 3;
    [SerializeField] private Camera cam1;
    public bool reabastece = false;
    private MenuCTRL IController;
    private InventarioCTRL inv;
    public Text ItemText;
    private Bau_Inv bau;
    [SerializeField] GameObject Bau_Canvas;
    bool open_close = false;
    int loop;
    public GameObject gm;

    public static bool podeInteragrir = false;
    public CanvasGroup botaoInteragir;
    public static CanvasGroup _botaoInteragir;

    // Start is called before the first frame update
    void Start()
    {
        //bau = FindAnyObjectByType<Bau_Inv>();
        cam1 = Camera.main;
        // IController = FindAnyObjectByType<MenuCTRL>();
        //inv = FindAnyObjectByType<InventarioCTRL>();
        gm = GameObject.Find("GameManager").gameObject;
        _botaoInteragir = botaoInteragir;
    }

    // Update is called once per frame
    void Update()
    {

        return;
        cam1 = Camera.main;
        RaycastHit hit;
        Ray ray = cam1.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        if (Physics.Raycast(ray, out hit, distancia))
        {
            if (podeInteragrir)
            {

                //botaoInteragir.alpha = 1;

                //IController.ItemText.text = "pressione (E) para abastercer o carro ";
                /*
                for (int i = 0; i < inv.slots.Count; i++)
                {
                    if (inv.slots[i].ItemName == "Galão de Combustivel")
                    {

                        reabastece = true;
                        loop = i;
                        break;
                    }
                }
                */

                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (reabastece)
                    {
                        hit.collider.GetComponentInParent<CarController>().gasolina();
                        inv.slotsAmount[loop]--;
                        ToastNotification.Show("Carro abastecido \n Nivel do combustivel: " + carGas);
                        if (inv.slotsAmount[loop] == 0)
                        {
                            inv.slots[loop] = null;
                            inv.slots3D[loop].sprite = null;
                            inv.Barra_Inv[loop].sprite = null;
                        }
                    }
                }
            }
            else if (hit.collider.tag != "Car" || hit.collider.tag == null)
            {
                reabastece = false;
                loop = 0;
            }
        }
        else
        {
            //botaoInteragir.alpha = 0;
            //IController.ItemText.text = null;
        }


        //--------------------------------------------------------------------------------------------------

        if (Physics.Raycast(ray, out hit, distancia))
        {
            if (podeInteragrir)
            {
                IController.ItemText.text = "pressione (E) para abrir o Baú ";
                if (Input.GetKeyDown(KeyCode.E))
                {
                    open_close = !open_close;
                    Bau_Canvas.SetActive(open_close);
                    IController.bau();
                }
            }
        }
        else
        {
            //IController.ItemText.text = null;
        }

        if (Physics.Raycast(ray, out hit, distancia))
        {
            if (hit.collider.tag == "objeto")
            {
                
                if (Input.GetKeyDown(KeyCode.E))
                {
                    gm.GetComponent<MissoesP1>().Pedras();
                    Destroy(hit.collider.gameObject);
                }

                //botaoInteragir.alpha = 1;
                //    ItemText.text = "Press (E) to colect";
            }
            else
            {
                //botaoInteragir.alpha = 0;
                //ItemText.text = null;
            }
        }
    }

    public static void ExibeInteracao(bool exibir)
    {
        podeInteragrir = exibir;
        _botaoInteragir.alpha = exibir == true ? 1 : 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.name == "Interacao")
        {
            ExibeInteracao(true);

            // Primeira interação com o carro
            if (other.transform.parent.Find("SetaCarro"))
                other.transform.parent.Find("SetaCarro").gameObject.SetActive(false);

            // Remove setas das pedras
            if (other.transform.parent.Find("SetaPedra"))
                other.transform.parent.Find("SetaPedra").gameObject.SetActive(false);

            

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Interacao")
        {
            if (Input.GetAxis("Fire7") != 0 && podeInteragrir && other.transform.parent.CompareTag("objeto") )
            {
                gm.GetComponent<MissoesP1>().Pedras();
                other.transform.parent.gameObject.SetActive(false);
                MissoesGeral.instance.AtualizarMissaoPedras();
                ExibeInteracao(false);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Interacao")
        {
            ExibeInteracao(false);
        }
    }

}

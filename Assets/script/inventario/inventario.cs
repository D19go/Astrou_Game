using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inventario : MonoBehaviour
{
    
    [SerializeField] private float raycastDistance = 50f;
    RaycastHit hit;
    bool showInventory = false;
    // listar todos os paineis de itens
    public Texture espada;  
    
    public Camera main;
    public Camera playerCamera;
    [SerializeField] private TextMeshProUGUI descript;
    [SerializeField] private TextMeshProUGUI nome;
    bool came = true;

    // Start is called before the first frame update
    void Start()
    {
        main = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {

        if(came){
            if (Physics.Raycast(main.transform.position, main.transform.forward, out hit, raycastDistance))
            {

                if (hit.collider.CompareTag("PeRadio1"))
                {
                    Debug.Log("pedra1");
                    GameObject.Find("slot 1").transform.Find("RawImage").GetComponent<RawImage>().enabled = true;
                    GameObject.Find("slot 1").transform.Find("RawImage").GetComponent<RawImage>().texture = espada;
                }

                if (hit.collider.CompareTag("PeRadio2"))
                {
                    Debug.Log("pedra2");
                    GameObject.Find("slot 2").transform.Find("RawImage").GetComponent<RawImage>().enabled = true;
                    GameObject.Find("slot 2").transform.Find("RawImage").GetComponent<RawImage>().texture = espada;
                }

                if (hit.collider.CompareTag("PeRadio3"))
                {
                    Debug.Log("pedra3");
                    GameObject.Find("slot 3").transform.Find("RawImage").GetComponent<RawImage>().enabled = true;
                    GameObject.Find("slot 3").transform.Find("RawImage").GetComponent<RawImage>().texture = espada;
                }

                if (hit.collider.CompareTag("PeRadio4"))
                {
                    Debug.Log("pedra4");
                    GameObject.Find("slot 4").transform.Find("RawImage").GetComponent<RawImage>().enabled = true;
                    GameObject.Find("slot 4").transform.Find("RawImage").GetComponent<RawImage>().texture = espada;
                }
            }
        }else{
   
            if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, raycastDistance))
            {
                if (hit.collider.CompareTag("PeRadio1"))
                {
                    Debug.Log("pedra1");
                    GameObject.Find("slot 1").transform.Find("RawImage").GetComponent<RawImage>().enabled = true;
                    GameObject.Find("slot 1").transform.Find("RawImage").GetComponent<RawImage>().texture = espada;
                }

                if (hit.collider.CompareTag("PeRadio2"))
                {
                    Debug.Log("pedra2");
                    GameObject.Find("slot 2").transform.Find("RawImage").GetComponent<RawImage>().enabled = true;
                    GameObject.Find("slot 2").transform.Find("RawImage").GetComponent<RawImage>().texture = espada;
                }

                if (hit.collider.CompareTag("PeRadio3"))
                {
                    Debug.Log("pedra3");
                    GameObject.Find("slot 3").transform.Find("RawImage").GetComponent<RawImage>().enabled = true;
                    GameObject.Find("slot 3").transform.Find("RawImage").GetComponent<RawImage>().texture = espada;
                }

                if (hit.collider.CompareTag("PeRadio4"))
                {
                    Debug.Log("pedra4");
                    GameObject.Find("slot 4").transform.Find("RawImage").GetComponent<RawImage>().enabled = true;
                    GameObject.Find("slot 4").transform.Find("RawImage").GetComponent<RawImage>().texture = espada;
                }
            }
        }
        
       
    }

    public void pegarItem( string nome ){
        if( nome == "espada" ){
            GameObject.Find("slot_1").transform.Find("RawImage").GetComponent<RawImage>().enabled = true;
            GameObject.Find("slot_1").transform.Find("RawImage").GetComponent<RawImage>().texture = espada;
        }
    }

    public void camTrade(bool cams){
        came = cams;
    }

}
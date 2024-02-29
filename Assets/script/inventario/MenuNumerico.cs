using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuNumerico : MonoBehaviour
{
    [SerializeField] private GameObject canvasItens;
    InventarioCTRL inv_Player;
    bool act = false;
    public List<Image> barraInferior;
    [SerializeField] GameObject canhao;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1)){
            act =! act;
            canhao.GetComponent<nhao>().CanhaoPronto = act;
        }
        /*
        if(Input.GetKeyDown(KeyCode.Alpha2)){
            if(barraInferior[1].sprite != null){
                
            }

        }   
        if(Input.GetKeyDown(KeyCode.Alpha3)){
            if(barraInferior[2].sprite != null){
                
            }

        }
        if(Input.GetKeyDown(KeyCode.Alpha4)){
            if(barraInferior[3].sprite != null){
                
            }

        }
        if(Input.GetKeyDown(KeyCode.Alpha5)){
            if(barraInferior[4].sprite != null){
                
            }

        }
        if(Input.GetKeyDown(KeyCode.Alpha6)){
            if(barraInferior[5].sprite != null){
                
            }

        }
        if(Input.GetKeyDown(KeyCode.Alpha7)){
           if(barraInferior[6].sprite != null){
                
            }

        }
        if(Input.GetKeyDown(KeyCode.Alpha8)){
            if(barraInferior[7].sprite != null){
                
            }

        }*/
        
    }
}

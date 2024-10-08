using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Unity.Services.Lobbies.Models;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static int pontuacao = 0;
    public static string ganhou;
    public static int Vida = 10;
    public static int VidaEnemy = 2;
    [SerializeField] private GameObject cam1p;
    [SerializeField] private GameObject cam3p;
    [SerializeField] private GameObject canhao;
    [SerializeField] private GameObject Hplayer;
    [SerializeField] private GameObject menuPortatil;

    bool painel = false;

    bool cams = true;

    // public static int porcentagem = 0;

    void Start(){

        // Conrado: isso aqui tava dando erro em mapa que não tinha missão, como no começo. Já consertei, de nada...
        MissoesP1 missoes = GetComponent<MissoesP1>();
        if (missoes)
            missoes.ListaMissoes();
    }

    void Update(){
        
        if(Input.GetKeyDown(KeyCode.P)){
            if(Input.GetKeyDown(KeyCode.L)){
                if(Input.GetKeyDown(KeyCode.I)){
                    SceneManager.LoadScene("Começo");
                }
            }
        }
        
        if(Input.GetKeyDown(KeyCode.O)){
           if (cams){
                cam3p.SetActive(false);
                cam1p.SetActive(true);        
                cams = !cams;
                canhao.GetComponent<nhao>().CamMain(cams);
                Hplayer.GetComponent<Habilidades>().camTrade(cams);
            }else{
                cam3p.SetActive(true);
                cam1p.SetActive(false);  
                cams =! cams; 
                canhao.GetComponent<nhao>().CamMain(cams);
                Hplayer.GetComponent<Habilidades>().camTrade(cams);
            }

        }

        if(Input.GetKeyDown(KeyCode.Tab)){
            painel = !painel;
            menuPortatil.SetActive(painel);
            if (painel)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = painel;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = painel;
            }
        }  

    }
    
}


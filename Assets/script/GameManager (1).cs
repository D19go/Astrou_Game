using System.Collections;
using System.Collections.Generic;
using Cinemachine;
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

    bool cams = true;
    bool camsAct = true;

    // public static int porcentagem = 0;

    void Start(){
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.P)){
            if(Input.GetKeyDown(KeyCode.O)){
                if(Input.GetKeyDown(KeyCode.I)){
                    SceneManager.LoadScene("Começo");
                }
            }
        }
        // if(Input.GetKeyDown(KeyCode.O)){
        //     SceneManager.LoadScene("Lvl2");
        // }
        // if(Input.GetKeyDown(KeyCode.I)){
        //     SceneManager.LoadScene("RealLevel");
        // }
        // if(Input.GetKeyDown(KeyCode.L)){
        //     SceneManager.LoadScene("mundoTest");
        // }
        // if(Input.GetKeyDown(KeyCode.K)){
        //     SceneManager.LoadScene("InfSpace");
        // }
        if(Input.GetKeyDown(KeyCode.O)){
           if (cams){
            // Desativar a câmera em terceira pessoa e o segundo display
                cam3p.SetActive(false);
                cam1p.SetActive(true);        
                cams = !cams;
                canhao.GetComponent<nhao>().CamMain(cams);
            }else{
                cam3p.SetActive(true);
                cam1p.SetActive(false);  
                cams =! cams; 
                canhao.GetComponent<nhao>().CamMain(cams);
            }

        }
        

    }
    
}

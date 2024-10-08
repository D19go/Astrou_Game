using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class Habilidades : MonoBehaviour
{
    private bool Skill1 = true;
    private bool Skill2 = true;
    private bool Skill3 = true;
    private bool Skill3Recast = true;
    [SerializeField] private GameObject  escudo;
    [SerializeField] private GameObject  TpOBJ;
    private bool LancaTP = false;
    [SerializeField] private GameObject  SaidaTP;
    private Animator anim;
    [SerializeField] private int Forca = 5;

    private CharacterController controller;
    [SerializeField] private float jumpSpeed = 8.0f; // Velocidade de salto adicionada
    private Vector3 moveDirection = Vector3.zero;
    bool sim = true;
    public Camera mainCamera;
    public Camera playerCamera;
    bool camAtual = true;
    bool test = false;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
        controller = GetComponent<CharacterController>();
        anim = gameObject.GetComponentInChildren<Animator>();
        playerCamera = Camera.main;
    }
    void Update(){

        // Joystick: Y
        if ( (Input.GetKeyDown(KeyCode.G) || Input.GetAxis("Fire4") != 0) && Skill1)
        {   // Dash para trás
            if(camAtual){
            Vector3 cameraDirection = playerCamera.transform.forward; /* Obtém a direção para a qual a câmera está olhando*/            
            Vector3 jumpDirection = -cameraDirection; // Inverte a direção            
            controller.Move(jumpDirection * jumpSpeed * Time.deltaTime); // Aplica a força na direção oposta
            StartCoroutine(timeSkill());
            }else{
                Vector3 cameraDirection = mainCamera.transform.forward; /* Obtém a direção para a qual a câmera está olhando*/            
                Vector3 jumpDirection = -cameraDirection; // Inverte a direção            
                controller.Move(jumpDirection * jumpSpeed * Time.deltaTime); // Aplica a força na direção oposta
                StartCoroutine(timeSkill());              
            }
        }

        // Joystick: X
        if ( (Input.GetKeyDown(KeyCode.Q) || Input.GetAxis("Fire3") != 0) && Skill2){
            //escudo
            escudo.SetActive(true);
            StartCoroutine(timeSkill2());
            GetComponent<VidaPlayer>().Escudo_Ativo(sim);
            // sim = false
            sim =! sim;

        }


        // Joystick: RT  )
        if ( Input.GetKeyDown(KeyCode.R) || Input.GetAxis("Fire8") != 0)
        {
            //Teleporte
            if(camAtual){
                if(Skill3Recast == true) // Conrado: precisei adicionar isso para que funcionasse no controle
                {
                    if(!LancaTP && Skill3){
                        Vector3 direcao = playerCamera.transform.forward;
                        TpOBJ.transform.position = SaidaTP.transform.position;
                        TpOBJ.GetComponent<Rigidbody>().isKinematic = false;
                        TpOBJ.GetComponent<MeshRenderer>().enabled = true;
                        TpOBJ.GetComponent<Rigidbody>().velocity = Vector3.zero;
                        TpOBJ.GetComponent<Rigidbody>().AddForce(direcao * Forca);
                        StartCoroutine(timeSkill3());
                        LancaTP = true;
                    }else if(LancaTP){
                        Vector3 direcao = playerCamera.transform.forward;
                        GetComponent<CharacterController>().enabled = false;
                        transform.position = TpOBJ.transform.position;
                        GetComponent<CharacterController>().enabled = true;
                        LancaTP = false;
                    }
                }
            }else{
                if(!LancaTP && Skill3){
                    Vector3 direcao = mainCamera.transform.forward;
                    TpOBJ.transform.position = SaidaTP.transform.position;
                    TpOBJ.GetComponent<Rigidbody>().isKinematic = false;
                    TpOBJ.GetComponent<MeshRenderer>().enabled = true;
                    TpOBJ.GetComponent<Rigidbody>().velocity = Vector3.zero;
                    TpOBJ.GetComponent<Rigidbody>().AddForce(direcao * Forca);
                    StartCoroutine(timeSkill3());
                    LancaTP = true; 
                }else if(LancaTP){
                    Vector3 direcao = mainCamera.transform.forward;
                    GetComponent<CharacterController>().enabled = false;
                    transform.position = TpOBJ.transform.position;
                    GetComponent<CharacterController>().enabled = true;
                    LancaTP = false;
                }
            }
            
          
        }

        if(Input.GetKeyDown(KeyCode.M)){
            
            if (test)
            {
                /*Time.fixedDeltaTime = */Time.timeScale = 0.1f;
                test =! test;
            }
            else
            {
                /*Time.fixedDeltaTime = */ Time.timeScale = 1.5f;
                test =! test;
            }

        }
    }

    IEnumerator timeSkill(){
        Skill1 = false;
        yield return new WaitForSeconds(3f);
        Skill1 = true;

    }
    IEnumerator timeSkill2(){
        Skill2 = false;
        yield return new WaitForSeconds(5f);
        escudo.SetActive(false);    
        Skill2 = true;
        GetComponent<VidaPlayer>().Escudo_Ativo(sim);
        // sim = true
        sim =! sim;

    }

    IEnumerator timeSkill3(){
        Skill3 = false;
        Skill3Recast = false;
        yield return new WaitForSeconds(0.5f);
        Skill3Recast = true;
        yield return new WaitForSeconds(1.5f);
        Skill3 = true;
    }

    public void camTrade(bool cams){
        camAtual = cams;
    }
}

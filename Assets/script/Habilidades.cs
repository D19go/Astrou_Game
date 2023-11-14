using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Habilidades : MonoBehaviour
{
    private bool Skill1 = true;
    private bool Skill2 = true;
    private bool Skill3 = true;
    public GameObject  LancaChamas;
    public GameObject  TpOBJ;
    public GameObject  TpOBJ2;
    public GameObject  esc;
    private Animator anim;
    public int Forca = 5;
    Camera mainCamera;
    private CharacterController controller;
    public float jumpSpeed = 8.0f; // Velocidade de salto adicionada
    private Vector3 moveDirection = Vector3.zero;
        
    public Camera playerCamera;

        void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = true;
            controller = GetComponent<CharacterController>();
            anim = gameObject.GetComponentInChildren<Animator>();
        }
    void Update(){
        
        if (Input.GetKeyDown(KeyCode.G) && Skill1)
        {
            // Obtém a direção para a qual a câmera está olhando
            Vector3 cameraDirection = playerCamera.transform.forward;
            // Inverte a direção
            Vector3 jumpDirection = -cameraDirection;
            // Aplica a força na direção oposta
            controller.Move(jumpDirection * jumpSpeed * Time.deltaTime);
            StartCoroutine(timeSkill());
        }

        if(Input.GetKeyDown(KeyCode.F) && Skill2){
            LancaChamas.SetActive(true);
            StartCoroutine(timeSkill2());
        }

        if(Input.GetKeyDown(KeyCode.R) && Skill3){
            GameObject tele = Instantiate(TpOBJ, transform.position, Quaternion.identity);
            // Obter a direção olhando para o ponto em que a câmera está apontando
            Vector3 direcao = playerCamera.transform.forward;
            tele.GetComponent<Rigidbody>().AddForce(direcao * Forca);

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
        Skill2 = true;
        LancaChamas.SetActive(false);
    }

    IEnumerator timeSkill3(){
        Skill3 = false;
        yield return new WaitForSeconds(1f);
        Skill3 = true;
    }
}

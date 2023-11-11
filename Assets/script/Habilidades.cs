using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Habilidades : MonoBehaviour
{
    private bool Skill1 = true;
    private Animator anim;
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
    }

    IEnumerator timeSkill(){
        Skill1 = false;
        yield return new WaitForSeconds(3f);
        Skill1 = true;

    }
}

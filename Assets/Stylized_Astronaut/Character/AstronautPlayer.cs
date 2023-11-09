using UnityEngine;
using System.Collections;

namespace AstronautPlayer
{
    public class AstronautPlayer : MonoBehaviour
    {
        private Animator anim;
        private CharacterController controller;

        public float speed = 6.0f;
        public float turnSpeed = 400.0f;
        public float jumpSpeed = 8.0f; // Velocidade de salto adicionada
        private Vector3 moveDirection = Vector3.zero;
        private bool isJumping = false; // Variável para rastrear se o personagem está pulando
        public float gravity = 20.0f;

        void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            controller = GetComponent<CharacterController>();
            anim = gameObject.GetComponentInChildren<Animator>();
        }

        void Update()
        {
            if (controller.isGrounded)
            {
                moveDirection = transform.forward * Input.GetAxis("Vertical") * speed;
                isJumping = false;

                if (Input.GetKeyDown(KeyCode.Space)) // Verificar se a tecla de espaço foi pressionada
                {
                    moveDirection.y = jumpSpeed; // Aplicar a velocidade de salto
                    isJumping = true;
                }
            }

            if (!isJumping)
            {
                float turn = Input.GetAxis("Horizontal");
                transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);
            }

            controller.Move(moveDirection * Time.deltaTime);
            moveDirection.y -= gravity * Time.deltaTime;
            
            // Configurar a animação com base na velocidade vertical para pular
            if (isJumping)
            {
                anim.SetInteger("AnimationPar", 2); // Defina o estado de pulo na animação
            }
            else if (Input.GetKey("w"))
            {
                anim.SetInteger("AnimationPar", 1);
            }
            else
            {
                anim.SetInteger("AnimationPar", 0);
            }
        }
    }
}

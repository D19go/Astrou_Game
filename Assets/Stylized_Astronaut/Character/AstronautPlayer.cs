using UnityEngine;

namespace AstronautPlayer
{
    public class AstronautPlayer : MonoBehaviour
    {
        private Animator anim;
        private CharacterController controller;

        public float speed = 6.0f;
        public float sprintSpeedMultiplier = 2.0f; // Fator de multiplicação para a velocidade de corrida
        public float turnSpeed = 400.0f;
        public float jumpSpeed = 8.0f;
        private Vector3 moveDirection = Vector3.zero;
        private bool isJumping = false;
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
                float currentSpeed = speed;

                // Verificar se a tecla "SHIFT" e "W" estão pressionadas para aumentar a velocidade
                if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey("w"))
                {
                    currentSpeed *= sprintSpeedMultiplier;
                }

                moveDirection = transform.forward * Input.GetAxis("Vertical") * currentSpeed;
                isJumping = false;

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    moveDirection.y = jumpSpeed;
                }
            }

            if (!isJumping)
            {
                float turn = Input.GetAxis("Horizontal");
                transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);
            }

            controller.Move(moveDirection * Time.deltaTime);
            moveDirection.y -= gravity * Time.deltaTime;

            if (isJumping)
            {
                anim.SetInteger("AnimationPar", 2);
            }
            else if (Input.GetKey("w") || (Input.GetKey(KeyCode.LeftShift) && Input.GetKey("w")))
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

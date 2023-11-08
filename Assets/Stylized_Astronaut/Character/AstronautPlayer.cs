using UnityEngine;

namespace AstronautPlayer
{
    public class AstronautPlayer : MonoBehaviour
    {
        private CharacterController controller;
		bool anda = true;
        public float speed = 6.0f;
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
        }

        void Update()
        {
            if (controller.isGrounded)
            {
                moveDirection = transform.forward * Input.GetAxis("Vertical") * speed;
                isJumping = false;

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    moveDirection.y = jumpSpeed;
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
        }
    }
}

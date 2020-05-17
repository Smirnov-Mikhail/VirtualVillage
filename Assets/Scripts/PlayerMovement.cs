using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerMovement : MonoBehaviour
    {
        public CharacterController controller;
        public Transform playerBody;

        public float speed = 12f;
        public float gravity = -9.81f;
        public float jumpHeight = 10f;

        public Transform groundCheck;
        public float groundDistance = 0.4f;
        public LayerMask groundMask;
        
        private Vector3 velocity;
        private bool isGrounded;

        private void Update()
        {
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;
            
            controller.Move(playerBody.rotation * move * (speed * Time.deltaTime));

            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }

            velocity.y += gravity * Time.deltaTime;
            
            controller.Move(velocity * Time.deltaTime);
        }

    }
}
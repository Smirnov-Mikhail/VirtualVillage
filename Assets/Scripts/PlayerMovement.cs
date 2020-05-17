using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private List<GameObject> houses;
        
    private void Awake()
    {
#if UNITY_WEBGL
        int pm = Application.absoluteURL.IndexOf("?", StringComparison.Ordinal);
        if (pm != -1)
        {
            var houseName = Application.absoluteURL.Split("?"[0])[1];
            var house = houses.FirstOrDefault(h => h.name == houseName);
            if (house != null)
            {
                transform.position = house.transform.position;
            }
        }         
#endif
    }

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
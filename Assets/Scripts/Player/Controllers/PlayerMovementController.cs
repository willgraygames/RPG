using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] float speed = 12f;
    [SerializeField] float gravityForce = -9.81f;
    [SerializeField] float jumpHeight = 3f;

    CharacterController controller;

    Vector3 velocity;
    
    bool isGrounded;
    [SerializeField] Transform groundCheck;
    [SerializeField] float groundDistance = 0.4f;
    [SerializeField] LayerMask groundMask;

    void Start () {
        InitializeReferences();
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfGrounded();
        MovePlayer();
        CheckJump();
        ApplyGravity();
    }

    void InitializeReferences () {
        controller = GetComponent<CharacterController>();
    }

    void MovePlayer() {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);
    }

    void CheckJump () {
        if (Input.GetButtonDown("Jump") && isGrounded) {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravityForce);
        }
    }

    void CheckIfGrounded() {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0) { velocity.y = -2f; }
    }

    void ApplyGravity() {
        velocity.y += gravityForce * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

}

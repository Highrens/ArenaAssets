using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    float horizontalMovement;
    float verticalMovement;
    public Transform playerCamera;
    Vector3 moveDirection;
    Rigidbody rb;

    public float moveSpeed;
    public float JumpForce;


     float rotationX;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //horizontalMovement = Input.GetAxisRaw("Horizontal");
        //verticalMovement = Input.GetAxisRaw("Vertical");

        //moveDirection = playerCamera.forward * verticalMovement + playerCamera.right * horizontalMovement;
        //rb.velocity = new Vector3(moveDirection.x * moveSpeed, rb.velocity.y, moveDirection.z * moveSpeed);


        //bool jump = Input.GetButtonDown("Jump");

        //if (jump)
        //{
        //    Jump();
        //}

        rotationX += -Input.GetAxis("Mouse Y") * 2;
        rotationX = Mathf.Clamp(rotationX, -80, 80);
        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X"), 0);

        //isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        //slopeMoveDirection = Vector3.ProjectOnPlane(moveDirection, slopeHit.normal);
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * JumpForce);
    }
}

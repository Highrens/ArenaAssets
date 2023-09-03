using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SC_FPSController : MonoBehaviour
{
    public float Horizontal;
    public float Vertical;
    public float walkingSpeed = 7.5f;
    public float runningSpeed = 14;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public Camera playerCamera;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;
    float movementDirectionY;

    public Vector3 moveDirection = Vector3.zero;



    public float damage_distance;
    public float fall_distance;
    Health health;

    [HideInInspector]
    public bool canMove = true;
    public float rotationX = 0;
    public CharacterController CC;
    void Start()
    {
        CC = GetComponent<CharacterController>();
        health = GetComponent<Health>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W) && CC.isGrounded) Vertical = 1;
        if (Input.GetKey(KeyCode.S) && CC.isGrounded) Vertical = -1;
        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S)) Vertical = 0;

        if (Input.GetKey(KeyCode.D) && CC.isGrounded) Horizontal = 1;
        if (Input.GetKey(KeyCode.A) && CC.isGrounded) Horizontal = -1;
        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D)) Horizontal = 0;

        // We are grounded, so recalculate move direction based on axes
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        // Press Left Shift to run
        float mobility = 1;
        if (GetComponentInChildren<pistol_n>())
        {
            mobility *= (float)GetComponentInChildren<pistol_n>().mobility / 100;
        }
        float speed = (health.isRunning ? runningSpeed : walkingSpeed) * mobility;
        float curSpeedX = canMove ? speed * Vertical : 0;
        float curSpeedY = canMove ? speed * Horizontal : 0;


        movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);
        


        if (Input.GetButton("Jump") && canMove && CC.isGrounded && health.stamina >= 10)
        {
            health.stamina -= 10;
            moveDirection.y = jumpSpeed;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        if (!CC.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }


        CC.Move(moveDirection * Time.deltaTime);


        // Player and Camera rotation
        if (canMove && GetComponent<InterFace>().gameIsPaused != true)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }
    }

}
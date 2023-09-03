using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class input : MonoBehaviour
{
    public float walkingSpeed = 7.5f;
    public float runningSpeed;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public Camera playerCamera;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;
    float movementDirectionY;

    CharacterController CC;
    public Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;

    public float damage_distance;
    float fall_distance;
    Health health;

    [HideInInspector]
    public bool canMove = true;

    void Start()
    {
        CC = GetComponent<CharacterController>();
    }

    void Update()
    {


        // We are grounded, so recalculate move direction based on axes
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        // Press Left Shift to run

        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Horizontal") : 0;
        movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);



        if (Input.GetButton("Jump") && canMove && CC.isGrounded)
        {
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

            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        

        if (CC.isGrounded == false)
        {
            fall_distance = moveDirection.y + 8;
        }
        else
        {
            if (fall_distance <= -damage_distance)
            {
                health.Player_health += fall_distance * 6;
            }
            fall_distance = 0;
        }
    }
}
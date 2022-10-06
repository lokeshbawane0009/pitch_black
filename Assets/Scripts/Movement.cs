using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class Movement : MonoBehaviour
{
    [SerializeField] float horizontal, vertical;
    [SerializeField] CharacterController player_character_controller;
    [SerializeField] Rigidbody player_rb;
    [SerializeField] float walk_speed, run_speed;
    [SerializeField] new Transform camera;
    [SerializeField] Vector3 movementVector;
    [SerializeField] bool crouch;

    float speed;
    [SerializeField] private float jumpHeight = 5f;
    [SerializeField] private float gravityValue = -9.8f;

    private void OnEnable()
    {
        camera = GetComponent<PlayerController>().camera;
        PlayerController.locomotion += MovementLogic;
    }

    private void OnDisable()
    {
        PlayerController.locomotion -= MovementLogic;
    }

    void MovementLogic()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        Vector3 movementDirection = camera.transform.right * horizontal + camera.transform.forward * vertical;

        if (player_character_controller.isGrounded && player_character_controller.velocity.y < 0)
        {
            movementVector.y = 0f;
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            crouch = !crouch;

            if (!crouch)
                player_character_controller.Move(new Vector3(0, 0.15f, 0));
        }

        if (crouch)
        {
            player_character_controller.height = 0.5f;
        }
        else
        {
            player_character_controller.height = 1.5f;
        }

        if (Input.GetKeyDown(KeyCode.Space) && player_character_controller.isGrounded)
        {
            movementVector = Jump(movementVector);
        }

        //If input then Move
        if (horizontal != 0 || vertical != 0)
        {
            //Set speed value;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                speed = run_speed;
            }
            else
            {
                speed = walk_speed;
            }
        }
        movementVector = new Vector3(movementDirection.x * speed, movementVector.y, movementDirection.z * speed);
        movementVector.y += gravityValue * Time.deltaTime;
        player_character_controller.Move(movementVector * Time.deltaTime);
    }
    Vector3 Jump(Vector3 movement)
    {
        return (movementVector = new Vector3(0, Mathf.Sqrt(jumpHeight * -3.0f * gravityValue), 0));
    }
}

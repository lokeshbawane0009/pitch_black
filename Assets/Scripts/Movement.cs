using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class Movement : MonoBehaviour
{
    [SerializeField] float horizontal, vertical;
    [SerializeField] CharacterController player_character_controller;
    [SerializeField] Rigidbody player_rb;
    [SerializeField] float walk_speed,run_speed;
    [SerializeField] new Transform camera;
    [SerializeField] Vector3 movementVector;
    [SerializeField] bool crouch;

    float speed;

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

        Vector3 movementDirection = camera.transform.right*horizontal+camera.transform.forward*vertical;

        if (player_character_controller.isGrounded && player_character_controller.velocity.y < 0)
        {
            print("CharacterController is grounded");
            player_character_controller.Move(new Vector3(0, 0, 0));
        }
        else
        {
            player_character_controller.Move(new Vector3(0, -9.8f * Time.deltaTime, 0));
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            crouch = !crouch;

            if(!crouch)
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

            if (player_character_controller.isGrounded)
            {
                movementVector = new Vector3(movementDirection.x * speed * Time.deltaTime, 0, movementDirection.z * speed * Time.deltaTime);
                player_character_controller.Move(movementVector);
            }
            //player_rb.velocity = new Vector3(movementDirection.x * speed * Time.deltaTime, player_rb.velocity.y, movementDirection.z * speed * Time.deltaTime);
        }

    }
}

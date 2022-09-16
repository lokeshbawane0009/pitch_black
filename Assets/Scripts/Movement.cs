using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class Movement : MonoBehaviour
{
    [SerializeField] float horizontal, vertical;
    [SerializeField] Rigidbody player_rb;
    [SerializeField] float speed;
    [SerializeField] new Transform camera;

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


        Vector3 inputDirection = new Vector3(horizontal, 0, vertical);
        Vector3 movementDirection = camera.transform.right*inputDirection.x+camera.transform.forward*inputDirection.z;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 150f;
        }
        else
        {
            speed = 100f;
        }

        if(horizontal!=0 || vertical!=0)
            player_rb.velocity = new Vector3(movementDirection.x * speed * Time.deltaTime,player_rb.velocity.y,movementDirection.z*speed*Time.deltaTime);
    }
}

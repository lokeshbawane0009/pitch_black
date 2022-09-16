using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public delegate void Locomotion();
    public static event Locomotion locomotion;

    public new Transform camera;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void FixedUpdate()
    {
        if (locomotion != null)
        {
            locomotion();
        }
    }
}

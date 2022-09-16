using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] new Transform camera;
    private void OnEnable()
    {
        camera = GetComponent<PlayerController>().camera;
        PlayerController.locomotion += RotationLogic;
    }

    private void OnDisable()
    {
        PlayerController.locomotion -= RotationLogic;
    }

    void RotationLogic()
    {
        transform.forward = camera.forward;
        Quaternion rotation = transform.rotation;
        rotation.x = rotation.z = 0;
        transform.rotation = rotation;
    }

}

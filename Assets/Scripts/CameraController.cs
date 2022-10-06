using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform camera;
    [SerializeField] Transform followTarget;
    [SerializeField] Vector3 offset;

    [SerializeField] private float xRotation = 0.0f;
    [SerializeField] private float yRotation = 0.0f;
    [SerializeField] float sensitivity;

    void Update()
    {
        camera.position = followTarget.position + offset;

        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 70);

        camera.transform.eulerAngles = new Vector3(xRotation, yRotation, 0.0f);
    }
}

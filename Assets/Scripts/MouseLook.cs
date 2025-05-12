using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
public float rotationSpeed = 1f;

void Start()
{
    Cursor.lockState = CursorLockMode.Locked;
    Cursor.visible = false;
}
    void Update() {
        // Get mouse input
        float horizontalInput = Input.GetAxis("Mouse X");

        // Apply rotation
        transform.Rotate(Vector3.up, horizontalInput * rotationSpeed);
    }
}

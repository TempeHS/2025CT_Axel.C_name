using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float sensitivity = 1.5f;
    public float smoothing = 1.5f; 

    private float xMousePos;
    private float smoothedMousePos;

    private float currentLookingPos;


    void start ()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }


    // Update is called once per frame
    void Update()
    {
        GetInput();
        ModifyInput();
        MovePlayer();
    }


    void GetInput()
    {
        xMousePos = Input.GetAxisRaw("Mouse X");

    }

    void ModifyInput()
    {
        xMousePos *= sensitivity * smoothing;
        smoothedMousePos = Mathf.Lerp(smoothedMousePos, xMousePos, 1f / smoothing);


    }

    void MovePlayer()
    {
        currentLookingPos *= smoothedMousePos;
        transform.localRotation = Quaternion.AngleAxis(currentLookingPos, transform.up); // value 1 is what we are rotating, and value 2 is the axis we are rotating around.
    }
}

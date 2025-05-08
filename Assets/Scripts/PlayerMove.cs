using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float playerSpeed = 20f;
    private CharacterController playerCC;

    private Vector3 inputVector;
    private Vector3 movementVector;
    private float myGravity = -10f;

    // Start is called before the first frame update
    void Start()
    {
        playerCC = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        MovePlayer();
    }



    void GetInput()
    {
        inputVector = new Vector3(Input.GetAxisRaw("Horizontal"), 0f , Input.GetAxisRaw("Vertical")); // This is getting the position of the player and logging it in the vector 3 variable that we created
        inputVector.Normalize(); // This allows for diagonal movement by normalising or averaging the x and z points of movement
        inputVector = transform.TransformDirection(inputVector); // This makes the player move in whichever direction it is facing rather than having "forwards" as a fixed direction

        movementVector = (inputVector * playerSpeed) + (Vector3.up * myGravity);  //multiplies the input by the player speed number which can make adjustable speed and sets up the y-axis gravity stuff (".up" on vector3 means y-axis)
    }


    void MovePlayer()
    {
        playerCC.Move(movementVector * Time.deltaTime);

    }
}

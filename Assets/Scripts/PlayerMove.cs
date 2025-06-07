using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMove : MonoBehaviour
{
    public float playerSpeed = 8f;
    private CharacterController playerCC;

    public Animator camAnim;
    public Animator camspriteAnim;
    private bool isWalking;

    private Vector3 inputVector;
    private Vector3 movementVector;
    private float myGravity = -10f;
    public TextMeshProUGUI vanText;
    public TextMeshProUGUI vanReport;
    private bool vanReportStatus = false;
    private bool isNearVan = false;

    // Start is called before the first frame update 
    void Start()
    {
        playerCC = GetComponent<CharacterController>();
        vanText.text = "  ";
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        MovePlayer();
        CheckIfWalking();
        CheckIfVanReportAvailable();
        DisplayVanReport();
        camAnim.SetBool("isWalking", isWalking);
        camspriteAnim.SetBool("isWalking", isWalking);
        
    }



    void GetInput()
    {
        inputVector = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical")); // This is getting the position of the player and logging it in the vector 3 variable that we created
        inputVector.Normalize(); // This allows for diagonal movement by normalising or averaging the x and z points of movement
        inputVector = transform.TransformDirection(inputVector); // This makes the player move in whichever direction it is facing rather than having "forwards" as a fixed direction

        movementVector = (inputVector * playerSpeed) + (Vector3.up * myGravity);  //multiplies the input by the player speed number which can make adjustable speed and sets up the y-axis gravity stuff (".up" on vector3 means y-axis)
    }


    void MovePlayer()
    {
        playerCC.Move(movementVector * Time.deltaTime);

    }

    void CheckIfWalking()
    {
        if (playerCC.velocity.magnitude > 0.1f) // checking if the player is walking which can be accessed by the "iswalking" variable
        {
            isWalking = true;
        }
        else
        {
            isWalking = false;
        }
    }

    void DisplayVanReport()
    {
        if (vanReportStatus == true)
        {
            vanReport.text = "You have photographed: " + CameraScripty.bodyCount + " bodies.";
        }
        else
        {
            vanReport.text = " ";
        }
    }
    void CheckIfVanReportAvailable()
    {
        if (isNearVan && Input.GetKeyDown(KeyCode.E))
        {
            vanReportStatus = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Van"))
        {
            vanText.text = "Press E to deposit footage"; 
            isNearVan = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        vanText.text = "  ";
        isNearVan = false;
        vanReportStatus = false;
    }
    

}

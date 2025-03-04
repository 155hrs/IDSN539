using UnityEngine;

public class FPSPlayer : MonoBehaviour
{
    int moveSpeed = 5;
    float lookSpeedX = 6; //left/right mouse sensitivity
    float lookSpeedY = 3; //up/down mouse sensitivity

    Transform camTrans; // a reference to the camera transform
    float xRotation;
    float yRotation;
    int jumpForce = 300;
    public LayerMask groundLayer;
    public Transform feetTrans;
    float groundCheckDist = .5f;
    public bool grounded = false;

    Rigidbody rb;
    void Start()
    {
        camTrans = Camera.main.transform;
        // Cursor.lockState = CursorLockMode.Locked;

        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        //Creates a movement vector local to the direction the player is facing
        Vector3 moveDir = transform.forward * Input.GetAxisRaw("Vertical") + transform.right * Input.GetAxis("Horizontal");
        moveDir *= moveSpeed;
        moveDir.y = rb.linearVelocity.y; // We dont want y (of the scene?) so we replace y with the rb.linearVelocity.y
        rb.linearVelocity = moveDir; // Set the velocity to our movement vector

        grounded = Physics.CheckSphere(feetTrans.position, groundCheckDist, groundLayer);
    }
 
    void Update()
    {
        yRotation += Input.GetAxis("Mouse X") * lookSpeedX;
        xRotation -= Input.GetAxis("Mouse Y") * lookSpeedY; // Y is inverted
        xRotation = Mathf.Clamp(xRotation, -90, 90); // Keeps up and down head rotation realistic
        camTrans.localEulerAngles = new Vector3(xRotation, 0, 0);
        transform.eulerAngles = new Vector3(0, yRotation, 0);

        if (grounded && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(new Vector3(0, jumpForce, 0));
        }

        

    }
}

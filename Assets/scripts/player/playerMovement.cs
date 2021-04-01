using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public Transform groundCheck;
    public LayerMask groundMask;
    public cameraFolow cam;
    private climbingSystem climbingSystem;
    private GameObject exitClimbMode;
    private CharacterController controller;
    private Vector3 velocity;

    public float endurence = 1;
    public float speed = 4f;
    private float gravity = -9.81f;
    private float groundRadius = 0.5f;
    private float jumpHeight = 1f;

    public bool isGrounded;
    public bool canMove;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
        climbingSystem = GetComponent<climbingSystem>();
        exitClimbMode = GameObject.Find("exitClimbMode");

        canMove = true;
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundRadius, groundMask);

        if(isGrounded)
        {
            climbingSystem.Climb = false;

            if(endurence < 1f)
            {
                endurence += 0.002f;
            }

            if(velocity.y < 0)
            {
                velocity.y = -2f;
            }

            if(Input.GetButtonDown("Jump") && !climbingSystem.Climb && canMove)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
            }
        }

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if(direction.magnitude >= 0.1f)
        {
            if(cam.cameraIsDown && !climbingSystem.Climb && canMove)
            {
                //change la direction du joueur
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);
                
                controller.Move(direction * speed * Time.deltaTime);
            }
        }

        //gravité
        if(!climbingSystem.Climb)
        {
            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        }
    }
}

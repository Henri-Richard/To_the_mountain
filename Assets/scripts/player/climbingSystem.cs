using UnityEngine;

public class climbingSystem : MonoBehaviour
{
    private CharacterController controller;
    private playerMovement playerMovement;
    public GameObject exitClimbMode;
    public Vector3 direction;

    public bool Climb;

    private float climbSpeed = 2f;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
        playerMovement = GetComponent<playerMovement>();
    }

    void Update()
    {
        if(Climb)
        {
            if(playerMovement.endurence > 0f)
            {
                playerMovement.endurence -= 0.002f;

                if(direction.magnitude >= 0.1f)
                {
                    controller.Move(direction * climbSpeed * Time.deltaTime);
                }
                
                if(Input.GetButtonDown("Jump"))
                {
                    exitClimb();
                }
            }
            else
            {
                exitClimb();
            }
        }
    }

    void exitClimb()
    {
        Climb = false;
        transform.position = exitClimbMode.transform.position;
    }
}

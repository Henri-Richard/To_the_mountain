using UnityEngine;

public class climbingSystem : MonoBehaviour
{
    private CharacterController controller;
    public GameObject exitClimbMode;
    public Vector3 direction;

    public bool Climb;

    private float climbSpeed = 2f;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if(Climb)
        {
            if(direction.magnitude >= 0.1f)
            {
                controller.Move(direction * climbSpeed * Time.deltaTime);
            }

            if(Input.GetButtonDown("Jump"))
            {
                Climb = false;
                transform.position = exitClimbMode.transform.position;
            }
        }
    }
}

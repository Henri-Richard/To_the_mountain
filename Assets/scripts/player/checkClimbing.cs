using UnityEngine;

public class checkClimbing : MonoBehaviour
{
    private GameObject Player;
    public climbingSystem climbingSystem;
    public Inventaire Inventaire;
    RaycastHit hit;

    void Awake()
    {
        Player = GameObject.Find("groundCheck");
    }

    void Update()
    {
        transform.position = Player.transform.position;

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if(Physics.Raycast(transform.position, transform.forward, out hit, 0.6f)) //RAYCAST
        {
            if(Inventaire.tenueDEscalade)
            {
                climbingSystem.direction = new Vector3(horizontal, vertical, 0f).normalized;
                climbingSystem.Climb = true;
            }
        }
        else if(Physics.Raycast(transform.position, transform.right, out hit, 0.6f)) //RAYCAST
        {
            if(Inventaire.tenueDEscalade)
            {
                climbingSystem.direction = new Vector3(0f, horizontal, vertical).normalized;
                climbingSystem.Climb = true;
            }
        }
        else
        {
            climbingSystem.Climb = false;
        }
    }
}

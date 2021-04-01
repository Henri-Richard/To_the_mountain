
using UnityEngine;

public class water : MonoBehaviour
{
    private bool isSwiming = false;

    public playerMovement playerMovement;

    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Player")
        {
            isSwiming = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if(col.tag == "Player")
        {
            isSwiming = false;
        }
    }

    void Update()
    {
        if(isSwiming)
        {
            if(playerMovement.endurence > 0f)
            {
                swim();
            }
            else
            {
                drown();
            }
        }
    }

    void swim()
    {
        playerMovement.endurence -= 0.002f;
    }

    void drown()
    {
        playerMovement.canMove = false;
    }
}

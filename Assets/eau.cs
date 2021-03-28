using UnityEngine;

public class eau : MonoBehaviour
{
    private bool isSwiming;

    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "player")
        {
            isSwiming = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if(col.tag == "player")
        {
            isSwiming = false;
        }
    }

    void Update()
    {
        if(isSwiming)
        {
            swim();
        }
    }

    void swim()
    {
        
    }
}

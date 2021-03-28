using UnityEngine;

public class chessScript : MonoBehaviour
{
    public Inventaire inventaire;
    private GameObject player;

    private float distance;

    public string newObject;

    void Awake()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        distance = Vector3.Distance(transform.position, player.transform.position);

        if(distance < 2)
        {
            canOpenChess();
        }
    }

    void canOpenChess()
    {
        if(Input.GetButtonDown("Action"))
        {
            if(newObject == "tenueDEscaladeInvent")
            {
                inventaire.tenueDEscaladeInvent = true;
            }
        }
    }
}

using UnityEngine;

public class cameraFolow : MonoBehaviour
{
    private GameObject player;
    private Animator animator;

    private float timeOffset = 0.08f;

    public bool cameraIsDown = true;

    public Vector3 posOffset;
    private Vector3 velocity;

    void Awake()
    {
        player = GameObject.Find("Player");
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        animator.SetBool("isDown", true);
    }

    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, player.transform.position + posOffset, ref velocity, timeOffset);

        if(Input.GetKeyDown(KeyCode.Q))
        {
            if(cameraIsDown)
            {
                animator.SetBool("isDown", false);
                cameraIsDown = false;
            }
            else
            {
                animator.SetBool("isDown", true);
                cameraIsDown = true;
            }
        }
    }
}

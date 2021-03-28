using UnityEngine;

public class levelStreamingVolume : MonoBehaviour
{
    private MeshRenderer rendererMesh;

    void OnTriggerEnter(Collider col)
    {
        if(col.transform.tag == "canStream")
        {
            rendererMesh = col.GetComponent<MeshRenderer>();
            rendererMesh.enabled = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if(col.transform.tag == "canStream")
        {
            rendererMesh = col.GetComponent<MeshRenderer>();
            rendererMesh.enabled = false;
        }
    }
}

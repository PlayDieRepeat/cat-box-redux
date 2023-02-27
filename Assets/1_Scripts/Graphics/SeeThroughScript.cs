using UnityEngine;

public class SeeThroughScript : MonoBehaviour
{
    public static int PosID = Shader.PropertyToID("_PlayerPosition");
    public static int SizeID = Shader.PropertyToID("_Size");

    public Material wallMaterial;
    public Camera camera;
    public LayerMask mask;
    public float maxDistance = 3000; // some huge number
    void Update()
    {
        var dir = camera.transform.position - transform.position;
        var ray = new Ray(transform.position, dir.normalized);

        if(Physics.Raycast(ray, maxDistance, mask))
        {
            wallMaterial.SetFloat(SizeID, 1);
        } 
        else
        {
            wallMaterial.SetFloat(SizeID, 0);
        }

        var view = camera.WorldToViewportPoint(transform.position);
        wallMaterial.SetVector(PosID, view);
    }
}

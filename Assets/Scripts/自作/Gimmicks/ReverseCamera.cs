using UnityEngine;

public class ReverseCamera : MonoBehaviour
{
    [SerializeField]
    public Vector3 scale = new Vector3(1, -1, 1);


    void Start()
    {
        Camera.main.projectionMatrix = Camera.main.projectionMatrix * Matrix4x4.Scale(scale);
    }

    void OnPreCull()
    {
        Camera.main.ResetWorldToCameraMatrix();
        Camera.main.ResetProjectionMatrix();
        //Camera.main.projectionMatrix = Camera.main.projectionMatrix * Matrix4x4.Scale(scale);
    }

    void OnPreRender()
    {
        if (scale.x * scale.y * scale.z < 0)
        {
            GL.invertCulling = true;
        }
    }

    void OnPostRender()
    {
        GL.invertCulling = false;
    }
}
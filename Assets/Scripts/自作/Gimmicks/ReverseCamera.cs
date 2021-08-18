using UnityEngine;

public class ReverseCamera : MonoBehaviour
{
    [SerializeField]
    public Vector3 scale = new Vector3(1, -1, 1);
    [SerializeField]
    public Vector3 TextRotation = new Vector3(0, 0, 0);
    public GameObject text1;
    public GameObject text2;

    void Start()
    {
        Invoke("ReverseDisplay", 0.2f);
        //Camera.main.projectionMatrix = Camera.main.projectionMatrix * Matrix4x4.Scale(scale);
        //text1.transform.Rotate(TextRotation);
        //text2.transform.Rotate(TextRotation);
    }

    private void ReverseDisplay()
    {
        Camera.main.projectionMatrix = Camera.main.projectionMatrix * Matrix4x4.Scale(scale);
        text1.transform.Rotate(TextRotation);
        text2.transform.Rotate(TextRotation);
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

    void OnDisable()
    {
        TextRotation = new Vector3(0, 0, 0);
        scale =  new Vector3(1, 1, 1);
    }

}
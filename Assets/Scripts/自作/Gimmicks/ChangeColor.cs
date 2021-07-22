using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public string CeilingTag = "ceiling";
    public string GroundTag = "ground";
    public Color CeilingStartColor;
    public Color CeilingEndColor;
    public Color GroundStartColor;
    public Color GroundEndColor;
    public float ChangeFinTime; //��������

    //[Range(0f, 1f)]
    public AnimationCurve CeilingCurve;
    public AnimationCurve GroundCurve;
    private float t=0; //���ԃJ�E���^
    private int n = 0; //for�J�E���^
    GameObject[] CeilingOrder; //�V��
    GameObject[] GroundOrder;�@//��
    public LevelManager levelManager;

    //Renderer ThisRenderer;
    // Start is called before the first frame update
    void OnEnable()
    {
        //ThisRenderer = this.GetComponent<Renderer>();
        CeilingOrder = levelManager.CeilingOrder;
        GroundOrder = levelManager.GroundOrder;

    }
    void Start() //�����l
    {
        for (n = 0; n < CeilingOrder.Length; n++)
        {
            CeilingOrder[n].GetComponent<Renderer>().material.color = CeilingStartColor;
            GroundOrder[n].GetComponent<Renderer>().material.color = GroundStartColor;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //���񂾂�F���ς��
        if (t < 1f)
        {
            for (n = 0; n < CeilingOrder.Length; n++) // �^�O�̐������J��Ԃ�
            {
                //�V���z�u
                CeilingOrder[n].GetComponent<Renderer>().material.color = Color.Lerp(CeilingStartColor, CeilingEndColor, CeilingCurve.Evaluate(t)); //�ʒu�𔽉f

                //����z�u
                GroundOrder[n].GetComponent<Renderer>().material.color = Color.Lerp(GroundStartColor, GroundEndColor, GroundCurve.Evaluate(t)); //�ʒu�𔽉f

            }

            //ThisRenderer.material.color = Color.Lerp(startColor, endColor, curve.Evaluate(t));
            t += 1f / ChangeFinTime;
        }

    }
}

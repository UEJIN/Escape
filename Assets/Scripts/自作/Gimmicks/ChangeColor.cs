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
    public float ChangeFinTime; //完了時間

    //[Range(0f, 1f)]
    public AnimationCurve CeilingCurve;
    public AnimationCurve GroundCurve;
    private float t=0; //時間カウンタ
    private int n = 0; //forカウンタ
    GameObject[] CeilingOrder; //天井
    GameObject[] GroundOrder;　//床
    public LevelManager levelManager;

    //Renderer ThisRenderer;
    // Start is called before the first frame update
    void OnEnable()
    {
        //ThisRenderer = this.GetComponent<Renderer>();
        CeilingOrder = levelManager.CeilingOrder;
        GroundOrder = levelManager.GroundOrder;

    }
    void Start() //初期値
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
        //だんだん色が変わる
        if (t < 1f)
        {
            for (n = 0; n < CeilingOrder.Length; n++) // タグの数だけ繰り返し
            {
                //天井を配置
                CeilingOrder[n].GetComponent<Renderer>().material.color = Color.Lerp(CeilingStartColor, CeilingEndColor, CeilingCurve.Evaluate(t)); //位置を反映

                //床を配置
                GroundOrder[n].GetComponent<Renderer>().material.color = Color.Lerp(GroundStartColor, GroundEndColor, GroundCurve.Evaluate(t)); //位置を反映

            }

            //ThisRenderer.material.color = Color.Lerp(startColor, endColor, curve.Evaluate(t));
            t += 1f / ChangeFinTime;
        }

    }
}

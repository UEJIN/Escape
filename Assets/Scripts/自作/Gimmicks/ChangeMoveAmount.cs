using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMoveAmount : MonoBehaviour
{
    public string CeilingTag = "ceiling";
    [SerializeField]
    Vector3 AddStartPosition = new Vector3(0f, 1f, 0f); // 初期位置の変更

    GameObject[] CeilingOrder;
    private int n;
    LinerMove LinerMove;

    // Start is called before the first frame update
    void Start()
    {
        CeilingOrder = GameObject.FindGameObjectsWithTag(CeilingTag);//特定タグを配列化
        n = Random.Range(0, CeilingOrder.Length);
        LinerMove = CeilingOrder[n].GetComponent<LinerMove>(); //ランダムな天井のスクリプトを取り出す
        LinerMove.startPosition = CeilingOrder[n].transform.position + AddStartPosition;
    }

    // Update is called once per frame
    void Update()
    {
        //LinerMove.startPosition = CeilingOrder[n].transform.position + AddStartPosition;

        //startPosition = transform.position;
        //endPosition = transform.position + movePosition;

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class ChangeMoveAmount : MonoBehaviour
{
    public string CeilingTag = "ceiling"; 
    public string GroundTag = "ground";
    [ShowAssetPreview]
    public Sprite ChangeSprite;
 
    [SerializeField]
    Vector3 AddStartPosition = new Vector3(0f, 1f, 0f); // 初期位置の変更
    GameObject[] CeilingOrder;
    GameObject[] GroundOrder;
    private int n;
    LinerMove linerMove;
    public LevelManager levelManager;

    // Start is called before the first frame update
    void Start()
    {
        //配列化
        //CeilingOrder = GameObject.FindGameObjectsWithTag(CeilingTag);　//特定タグを配列化
        //GroundOrder = GameObject.FindGameObjectsWithTag(GroundTag); //
        CeilingOrder = levelManager.CeilingOrder; 
        GroundOrder = levelManager.GroundOrder;

        //移動開始位置変更
        n = Random.Range(0, CeilingOrder.Length);
        linerMove = CeilingOrder[n].GetComponent<LinerMove>(); //ランダムな天井のスクリプトを取り出す
        linerMove.startPosition = CeilingOrder[n].transform.position + AddStartPosition; //開始位置を変更
        
        //色を変えておく
        CeilingOrder[n].GetComponent<SpriteRenderer>().sprite = ChangeSprite;
        GroundOrder[n].GetComponent<SpriteRenderer>().sprite = ChangeSprite;
    }

    // Update is called once per frame
    void Update()
    {
        //LinerMove.startPosition = CeilingOrder[n].transform.position + AddStartPosition;

        //startPosition = transform.position;
        //endPosition = transform.position + movePosition;

    }
}

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
    Vector3 AddStartPosition = new Vector3(0f, 1f, 0f); // �����ʒu�̕ύX
    GameObject[] CeilingOrder;
    GameObject[] GroundOrder;
    private int n;
    LinerMove linerMove;
    public LevelManager levelManager;

    // Start is called before the first frame update
    void Start()
    {
        //�z��
        //CeilingOrder = GameObject.FindGameObjectsWithTag(CeilingTag);�@//����^�O��z��
        //GroundOrder = GameObject.FindGameObjectsWithTag(GroundTag); //
        CeilingOrder = levelManager.CeilingOrder; 
        GroundOrder = levelManager.GroundOrder;

        //�ړ��J�n�ʒu�ύX
        n = Random.Range(0, CeilingOrder.Length);
        linerMove = CeilingOrder[n].GetComponent<LinerMove>(); //�����_���ȓV��̃X�N���v�g�����o��
        linerMove.startPosition = CeilingOrder[n].transform.position + AddStartPosition; //�J�n�ʒu��ύX
        
        //�F��ς��Ă���
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

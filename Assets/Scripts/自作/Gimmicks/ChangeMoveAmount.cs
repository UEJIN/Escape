using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMoveAmount : MonoBehaviour
{
    public string CeilingTag = "ceiling";
    [SerializeField]
    Vector3 AddStartPosition = new Vector3(0f, 1f, 0f); // �����ʒu�̕ύX

    GameObject[] CeilingOrder;
    private int n;
    LinerMove LinerMove;

    // Start is called before the first frame update
    void Start()
    {
        CeilingOrder = GameObject.FindGameObjectsWithTag(CeilingTag);//����^�O��z��
        n = Random.Range(0, CeilingOrder.Length);
        LinerMove = CeilingOrder[n].GetComponent<LinerMove>(); //�����_���ȓV��̃X�N���v�g�����o��
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

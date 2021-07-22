using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperRandomChangeSprite : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public LevelManager levelManager;
    // public�Ő錾���Ainspector�Őݒ�\�ɂ���
    //private Sprite ChangeCeilingSprite;
    //private Sprite ChangeGroundSprite;
    GameObject[] CeilingOrder;
    GameObject[] GroundOrder;
    GameObject[] SpriteList;
    public GameObject SpriteParent;
    private int n;
    //public Sprite HoldSprite;
    //public Sprite SlashSprite;

    void OnEnable()
    {
        //����object��SpriteRenderer���擾



        //SpriteList�����z��
        GetAllChildObject();
        for (int i = 1; i < SpriteList.Length; i++)
        {
            //Debug.Log("levelLength" + LevelObjects.Length);
            SpriteList[i].SetActive(false);//���x���̎q�I�u�W�F�N�g����x��A�N�e�B�u��
        }

        CeilingOrder = levelManager.CeilingOrder;
        GroundOrder = levelManager.GroundOrder;
        //n = Random.Range(0, SpriteList.Length);

        for (int i = 0; i < CeilingOrder.Length; i++)
        {
            n = Random.Range(0, SpriteList.Length);
            spriteRenderer = CeilingOrder[i].GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = SpriteList[n].GetComponent<SpriteRenderer>().sprite;

            n = Random.Range(0, SpriteList.Length);
            spriteRenderer = GroundOrder[i].GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = SpriteList[n].GetComponent<SpriteRenderer>().sprite;
        }
    }

    private void GetAllChildObject()
    {
        SpriteList = new GameObject[SpriteParent.transform.childCount];

        for (int i = 0; i < SpriteParent.transform.childCount; i++)
        {
            SpriteList[i] = SpriteParent.transform.GetChild(i).gameObject;
        }
    }
}

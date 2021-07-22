using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprite : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public LevelManager levelManager;
    // publicで宣言し、inspectorで設定可能にする
    public Sprite ChangeCeilingSprite; 
    public Sprite ChangeGroundSprite;
    GameObject[] CeilingOrder;
    GameObject[] GroundOrder;

    //public Sprite HoldSprite;
    //public Sprite SlashSprite;

    void OnEnable()
    {
        //このobjectのSpriteRendererを取得

        CeilingOrder = levelManager.CeilingOrder;
        GroundOrder = levelManager.GroundOrder;

        for (int i = 0; i < CeilingOrder.Length; i++)
        {
            spriteRenderer = CeilingOrder[i].GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = ChangeCeilingSprite;
            spriteRenderer = GroundOrder[i].GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = ChangeGroundSprite;
        }
    }
}

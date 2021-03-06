using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class ChangeSprite : MonoBehaviour
{
        SpriteRenderer spriteRenderer;
        public LevelManager levelManager;
        // publicで宣言し、inspectorで設定可能にする

        [ShowAssetPreview]
        public Sprite ChangeCeilingSprite;

        [ShowAssetPreview]
        public Sprite ChangeGroundSprite;

        GameObject[] CeilingOrder;
        GameObject[] GroundOrder;
        public GameObject HighWall1;
        public GameObject HighWall2;
        public GameObject LowWall1;
        public GameObject LowWall2;


        //public Sprite HoldSprite;
        //public Sprite SlashSprite;

        void OnEnable()
        {


            CeilingOrder = levelManager.CeilingOrder;
            GroundOrder = levelManager.GroundOrder;
            //objectのSpriteRendererからspriteを取得
            HighWall1.GetComponent<SpriteRenderer>().sprite = ChangeCeilingSprite;
            HighWall2.GetComponent<SpriteRenderer>().sprite = ChangeCeilingSprite;
            LowWall1.GetComponent<SpriteRenderer>().sprite = ChangeGroundSprite;
            LowWall2.GetComponent<SpriteRenderer>().sprite = ChangeGroundSprite;


            for (int i = 0; i < CeilingOrder.Length; i++)
            {
                spriteRenderer = CeilingOrder[i].GetComponent<SpriteRenderer>();
                spriteRenderer.sprite = ChangeCeilingSprite;
                spriteRenderer = GroundOrder[i].GetComponent<SpriteRenderer>();
                spriteRenderer.sprite = ChangeGroundSprite;
            }
        }
}

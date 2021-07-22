using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprite : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public LevelManager levelManager;
    // public‚ÅéŒ¾‚µAinspector‚Åİ’è‰Â”\‚É‚·‚é
    public Sprite ChangeCeilingSprite; 
    public Sprite ChangeGroundSprite;
    GameObject[] CeilingOrder;
    GameObject[] GroundOrder;

    //public Sprite HoldSprite;
    //public Sprite SlashSprite;

    void OnEnable()
    {
        //‚±‚Ìobject‚ÌSpriteRenderer‚ğæ“¾

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

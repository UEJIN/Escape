using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class GameSpeedUp : MonoBehaviour
{
    [ShowNonSerializedField]
    public static float GameSpeed = 1.0f;
    public float PlusSpeed = 0.5f;
    [ShowNonSerializedField]
    public static float MaxSpeed = 2.0f;

    void OnEnable()
    {
        //�����l
        Time.timeScale = GameSpeed;
    }
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDisable()
    {
        //���Ƃɖ߂�
        //Time.timeScale = 1f;

        //���ǂ񂾂Ƃ��̓X�s�[�h�A�b�v�������
        GameSpeed += PlusSpeed;

        //����Ŏ~�܂�
        if (GameSpeed > MaxSpeed)
        {
            GameSpeed = MaxSpeed;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSpeedUp : MonoBehaviour
{
    public static float GameSpeed = 1f;
    public float PlusSpeed = 0.5f;
    public float MaxSpeed = 4f;

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
        Time.timeScale = 1f;

        //���ǂ񂾂Ƃ��̓X�s�[�h�A�b�v�������
        GameSpeed += PlusSpeed;

        //����Ŏ~�܂�
        if (GameSpeed > MaxSpeed)
        {
            GameSpeed = MaxSpeed;
        }
    }
}

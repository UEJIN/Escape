using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemEffect_LifeUp : MonoBehaviour
{

    public int ChangeLife = 1;
    private bool isFinish = false;

    // Start is called before the first frame update
    void Start()
    {
        isFinish = false;
    }

    // Update is called once per frame
    void Update()
    {
        //�������Ă�����i��j��V�[���ɏ������Ă���΁j��x����
        if(gameObject.scene.name == "DontDestroyOnLoad" && isFinish == false)
        {   
            isFinish = true;
            LifeManager.IniLife += ChangeLife;

        }

    }

    //�j�󎞂ɂ��Ƃɖ߂�
    void OnDisable()
    {
        //�������Č��ʂ��������Ă�����i��j��V�[���ɏ������Ă���΁j���Ƃɖ߂�
        if (gameObject.scene.name == "DontDestroyOnLoad" && isFinish == true)
        {
            isFinish = false;
            LifeManager.IniLife -= ChangeLife;
        }
    }


}

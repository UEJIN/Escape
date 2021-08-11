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
        //装備していたら（非破壊シーンに所属していれば）一度だけ
        if(gameObject.scene.name == "DontDestroyOnLoad" && isFinish == false)
        {   
            isFinish = true;
            LifeManager.IniLife += ChangeLife;

        }

    }

    //破壊時にもとに戻す
    void OnDisable()
    {
        //装備して効果が発動していたら（非破壊シーンに所属していれば）もとに戻す
        if (gameObject.scene.name == "DontDestroyOnLoad" && isFinish == true)
        {
            isFinish = false;
            LifeManager.IniLife -= ChangeLife;
        }
    }


}

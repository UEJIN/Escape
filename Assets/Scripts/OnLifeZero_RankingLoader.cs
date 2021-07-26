using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnLifeZero_RankingLoader : MonoBehaviour
{
    bool isFinish = false;
    public float DelayTime = 0.5f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (LifeManager.LifeNum == 0 && !isFinish)
        {
            isFinish = true;
            Invoke("ShowRanking", DelayTime);
            
        }
    }

    void ShowRanking()
    {
        naichilab.RankingLoader.Instance.SendScoreAndShowRanking(StageCounter.value, DifficultyManager.Difficulty - 1);
    }
}

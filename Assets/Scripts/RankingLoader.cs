using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankingLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
            naichilab.RankingLoader.Instance.SendScoreAndShowRanking(StageCounter.value);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

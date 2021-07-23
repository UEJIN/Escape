using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// カウンター本体
public class StageCounter : MonoBehaviour
{

    public static int value=0; // 共有するカウンター値
  
    void OnEnable()
    { // 最初に行う
        //DontDestroyOnLoad(this);
        value++;// カウンターを増やす
    }
}

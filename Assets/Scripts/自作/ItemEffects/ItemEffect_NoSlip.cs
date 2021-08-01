using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEffect_NoSlip : MonoBehaviour
{
    [SerializeField]
    private int SlipLevel = 7;
    //LevelManager LevelManager;

    // Start is called before the first frame update
    void OnEnable()
    {

    }

    void Start()
    {
        LevelManager.LevelObjects[SlipLevel].SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDisable()
    {

    }
}

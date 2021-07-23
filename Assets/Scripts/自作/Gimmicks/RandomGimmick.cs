using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomGimmick : MonoBehaviour
{
    
    private int RandomLevel;
    //LevelManager LevelManager;

    // Start is called before the first frame update
    void OnEnable()
    {
        RandomLevel = Random.Range(3, LevelManager.LevelObjects.Length-1);
        LevelManager.LevelObjects[RandomLevel].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDisable()
    {
        LevelManager.LevelObjects[RandomLevel].SetActive(false);
    }
}

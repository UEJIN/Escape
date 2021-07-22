using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomGimmick : MonoBehaviour
{
    
    private int RandomLevel;
    LevelManager levelManager;

    // Start is called before the first frame update
    void OnEnable()
    {
        RandomLevel = Random.Range(3, levelManager.LevelObjects.Length);
        levelManager.LevelObjects[RandomLevel].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDisable()
    {
        levelManager.LevelObjects[RandomLevel].SetActive(false);
    }
}

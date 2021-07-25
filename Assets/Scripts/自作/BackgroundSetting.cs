using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSetting : MonoBehaviour
{
    public GameObject[] Backgrounds;

    // Start is called before the first frame update
    void Start()
    {
        
        Backgrounds[DifficultyManager.Difficulty].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

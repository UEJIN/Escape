using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SE1_Pless : MonoBehaviour
{
    public float time = 5f;
    private bool isFinish;
    public AudioClip sound1;
    AudioSource audioSource;

    // Start is called before the first frame update
    void OnEnable()
    {
        //Component‚ðŽæ“¾
        audioSource = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(isFinish);
        
        if (isFinish == false && Time.timeSinceLevelLoad >= time)
        {
            //‰¹(sound1)‚ð–Â‚ç‚·
            audioSource.PlayOneShot(sound1);
            isFinish = true;
        }
        if (isFinish == true && Time.timeSinceLevelLoad < time)
        {
            isFinish = false;

        }
    }
}

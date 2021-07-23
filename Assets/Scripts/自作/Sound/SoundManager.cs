using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip[] audioClips;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Awake()
    {
        //Componentを取得
        audioSource = GetComponent<AudioSource>();
        //音(sound1)を難易度で変更
        audioSource.clip = audioClips[DifficultyManager.Difficulty - 1];
        audioSource.Play();
    }
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {

    }
}

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
        //Component���擾
        audioSource = GetComponent<AudioSource>();
        //��(sound1)���Փx�ŕύX
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

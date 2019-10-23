using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSpot : MonoBehaviour
{

    [HideInInspector] private AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void Play(AudioClip audio)
    {
        source.clip = audio;
        source.Play();
        Destroy(gameObject, audio.length+.1f);
    }


}

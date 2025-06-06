using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSfx : MonoBehaviour
{
    public AudioSource audioSourceSfx;

    public AudioClip audioClipBenar;
    public AudioClip audioClipSalah;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void SoundSfxBenaar()
    {
        audioSourceSfx.PlayOneShot(audioClipBenar);
    }

    public void SoundSfxSalah()
    {
        audioSourceSfx.PlayOneShot(audioClipSalah);
    }
}

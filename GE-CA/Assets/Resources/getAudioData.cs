using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (AudioSource))]
public class getAudioData : MonoBehaviour
{
    // Listen to the audio source every frame and get samples from spectrum data into the float array
    AudioSource a_audioSource;
    //
    public static float[] fa_samples = new float[512];

    // Start is called before the first frame update
    void Start()
    {
        a_audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        GetSpectrumAudioSource();
    }

    void GetSpectrumAudioSource()
    {
        a_audioSource.GetSpectrumData(fa_samples, 0, FFTWindow.Blackman);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (AudioSource))]
public class getAudioData : MonoBehaviour
{
    // Listen to the audio source every frame and get samples from spectrum data into the float array
    AudioSource a_audioSource;
    public static float[] fa_samples = new float[512];
    public static float[] freqBand = new float[8];


    // Start is called before the first frame update
    void Start()
    {
        a_audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        GetSpectrumAudioSource();
        MakeFrequencyBands();
        
    }

   

    void MakeFrequencyBands()
    {
        int count = 0;

        for (int i = 0; i < 8; i++)
        {
            float average = 0;
            int sampleCount = (int)Mathf.Pow(2, i) * 2;

            if (i == 7)
            {
                sampleCount += 2;
            }

            for (int j = 0; j < sampleCount; j++)
            {
                average += fa_samples[count] * (count + 1);
                count++;
            }

            average /= count;

            freqBand[i] = average * 10;
        }
    }

    void GetSpectrumAudioSource()
    {
        a_audioSource.GetSpectrumData(fa_samples, 0, FFTWindow.Blackman);
    }
}

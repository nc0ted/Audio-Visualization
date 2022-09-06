using System;
using UnityEngine;

public class AudioParse : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    public static float[] samples = new float[512];
    public static float[] freqBand = new float[32];

    private void Update()
    {
        GetAudioSpectrum();
        MakeFrequencyBands();
    }
    private void GetAudioSpectrum()
    {
        audioSource.GetSpectrumData(samples, 1, FFTWindow.Blackman);
    }

    private void MakeFrequencyBands()
    {
        int band = 0;
        for (int i = 0; i < freqBand.Length; i++)
        {
            float frequencySum = 0;
            int sampleCount = (int)Mathf.Lerp(2f, samples.Length, i / (float)freqBand.Length);
            print(sampleCount);

            for (int j = band; j < sampleCount; j++)
            {
                frequencySum += samples[band];
                band++;
            }

            freqBand[i] = frequencySum;
        }
    }
}

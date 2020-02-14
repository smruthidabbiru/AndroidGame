using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSpectrumData : MonoBehaviour
{
    public AudioSource _audioSource;
    public static float[] _Samples = new float[512];
    public static float[] _FrequencyBands = new float[8];
    public static float[] _BandBuffer = new float[8];
    float[] _BufferDecrease = new float[8];
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        getSpectrumAudioSource();
        makeFrequencyBands();
        BandBuffer();
    }
    void getSpectrumAudioSource()
    {
        _audioSource.GetSpectrumData(_Samples, 0, FFTWindow.Blackman);
    }
    void makeFrequencyBands()
    {
        //22000 Hz / 500 = 43 Hz per band
        int count = 0;
        for (int i = 0; i < 8; i++)
        {
            float average = 0;
            int sampleCount = (int)Mathf.Pow(2, i) * 2;
            if(i == 7)
            {
                sampleCount += 2;
            }
            for (int j = 0; j < sampleCount; j++)
            {
                average += _Samples[count] * (count + 1);
                count++;
            }
            average /= count;
            _FrequencyBands[i] = average;
        }
    }
    void BandBuffer()
    {
        for (int i = 0; i < 8; i++)
        {
            if(_FrequencyBands[i] > _BandBuffer[i])
            {
                _BandBuffer[i] = _FrequencyBands[i];
                _BufferDecrease[i] = .005f;
            }
            if (_FrequencyBands[i] < _BandBuffer[i])
            {
                _BandBuffer[i] -= _BufferDecrease[i];
                _BufferDecrease[i] *= 1.2f;
            }
        }
    }
}

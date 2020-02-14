using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BackGroundHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public Image Streaks;
    public int BandRed;
    public int BandGreen;
    public int BandBlue;
    public int BandAlpha;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Streaks.color = new Color(AudioSpectrumData._BandBuffer[BandRed]*2, AudioSpectrumData._BandBuffer[BandGreen]*2, AudioSpectrumData._BandBuffer[BandBlue]*2, AudioSpectrumData._BandBuffer[BandAlpha]*5.0f);
    }
}

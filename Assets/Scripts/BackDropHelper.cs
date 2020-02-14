using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BackDropHelper : MonoBehaviour
{
    public Image BackDrop;
    public int Band;
    public float MaxAlpha = 0.1f;
    public Color BackDropColor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        BackDropColor.a = AudioSpectrumData._BandBuffer[Band] / 1.5f;
        if(BackDropColor.a < 0.0f)
        {
            BackDropColor.a = 0.0f;
        }
        BackDrop.color = BackDropColor;
    }
}

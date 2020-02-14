using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtonMusic : MonoBehaviour
{
    // Start is called before the first frame update
    RectTransform rect;
    void Start()
    {
        rect = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        rect.transform.localScale = new Vector3(1.0f + (AudioSpectrumData._BandBuffer[1]/3), 1.0f + (AudioSpectrumData._BandBuffer[5]/3),1.0f);
    }
}

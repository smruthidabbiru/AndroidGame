using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
public class QUalityChanged : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider QualitySlider;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void QualityChanged()
    {
        QualitySettings.SetQualityLevel((int)QualitySlider.value);
        File.WriteAllText(Application.persistentDataPath + "/QualitySettings/Quality.txt", QualitySlider.value.ToString());
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSpawner : MonoBehaviour
{
    public int BandNumber;
    public GameObject Prefab;
    public Transform targetTransform;
    public float AUdioLevels;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        AUdioLevels = AudioSpectrumData._BandBuffer[BandNumber];
        if (AudioSpectrumData._BandBuffer[BandNumber] >= 0.3f)
        {
            GameObject dummy = Instantiate<GameObject>(Prefab, targetTransform.position, Quaternion.identity);
        }
    }
}

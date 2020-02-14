using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    public int _band;
    public float _Alpha;
    public Material ParticleMaterial;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _Alpha = (AudioSpectrumData._BandBuffer[_band]*500)/255;
        ParticleMaterial.SetColor("_TintColor", new Color(0.5f,0.5f,0.5f,_Alpha));
        //new Color(128, 128, 128,Alpha);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetroGrid : MonoBehaviour
{
    public float scrollX = 0f;
    public float scrollY = 0f;

    private void Awake()
    {
       
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float offsetx = Time.time * scrollX;
        float offsety = Time.time * scrollY;
        //GetComponent<Renderer>().material.mainTextureOffset = new Vector2(offsetx, offsety);
        GetComponent<Renderer>().sharedMaterial.SetTextureScale("_EmissionMap", new Vector2(1.0f, 1.0f));
        GetComponent<Renderer>().sharedMaterial.SetTextureOffset("_EmissionMap", new Vector2(0f, 0f));
        GetComponent<Renderer>().sharedMaterial.SetTextureOffset("_MainTex", new Vector2(offsetx,offsety));
    }
}

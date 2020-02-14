using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class YellowScript : MonoBehaviour
{
    public GameObject YellowText;
    // Start is called before the first frame update
    void Start()
    {
        YellowText = GameObject.Find("YellowText");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

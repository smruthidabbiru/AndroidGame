using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectHelper : MonoBehaviour
{
    // Start is called before the first frame update
    public float time = 1;
    public SpriteRenderer SetImage;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        SetImage.color = new Color(1.0f, 1.0f, 1.0f, time / 1f);
        if(time <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}

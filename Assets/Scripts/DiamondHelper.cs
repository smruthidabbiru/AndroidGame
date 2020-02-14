using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondHelper : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject TargetHolder;
    public AudioSource RecievedSource;
    public AudioClip RecievedClip;
    void Start()
    {
        TargetHolder = GameObject.FindGameObjectWithTag("DiamondPlaceHolder");
        RecievedSource = Camera.main.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float Step = 6f * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, TargetHolder.transform.position, Step);
        if(transform.position == TargetHolder.transform.position)
        {
            RecievedSource.clip = RecievedClip;
            RecievedSource.Play();
            GameController.IncrementDiamondCount(1);
            Destroy(this.gameObject);
        }
    }
}

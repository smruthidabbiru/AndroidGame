using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationHandle : MonoBehaviour
{
    public bool RotateLeft;
    public Transform ImageTransfrom;
    public Transform TargetLeft;
    public Transform TargetRight;
    Transform rotater;
    bool left = false;
    // Start is called before the first frame update
    void Start()
    {
        if(RotateLeft)
        {
            transform.rotation = TargetLeft.rotation;
        }
        else
        {
            transform.rotation = TargetRight.rotation;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float step = 10.0f * Time.deltaTime;
        if(transform.rotation == TargetLeft.rotation)
        {
            left = false;
        }
        if(transform.rotation == TargetRight.rotation)
        {
            left = true;
        }
        if(left)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation,TargetLeft.rotation, step);
        }
        else
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, TargetRight.rotation, step);
        }
        
    }
}

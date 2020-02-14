using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretHandler : MonoBehaviour
{
    public GameObject EndPoint1;
    public GameObject EndPoint2;
    public float MovementSpeed = 1;
    public bool IsLeft = true;
    GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        if(IsLeft)
        {
            transform.position = new Vector3(transform.position.x, EndPoint1.transform.position.y, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, EndPoint2.transform.position.y, transform.position.z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float step = MovementSpeed * Time.deltaTime;
        if (transform.position.y <= EndPoint2.transform.position.y)
        {
            target = EndPoint1;
        }
        if (transform.position.y >= EndPoint1.transform.position.y)
        {
            target = EndPoint2;
        }
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, target.transform.position.y, transform.position.z), step);
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float BulletSpeed;
    GameObject target;
    bool Launch = false;
    // Start is called before the first frame update
    void Start()
    {
        this.tag = "Bullet";
    }

    // Update is called once per frame
    void Update()
    {
        if(Launch == true)
        {
            MovePosition();
        }

    }

    void MovePosition()
    {
        float step = BulletSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.transform.position.x,transform.position.y,transform.position.z), step);
        if (transform.position.x == target.transform.position.x)
        {
            Launch = false;
            Destroy(this.gameObject, 0.0f);
        }
    }
    public void InstantiateBullet(bool IsLeft)
    {
        if (IsLeft)
        {
            target = GameObject.FindWithTag("LeftEnd");
            Launch = true;
        }
        else
        {
            target = GameObject.FindWithTag("RightEnd");
            Launch = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject, 0.0f);
    }
}

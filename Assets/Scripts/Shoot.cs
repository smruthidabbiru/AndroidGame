using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject Turret;
    public GameObject BulletObj;
    public AudioSource HitAudioSource;
    public AudioClip HitAudioClip;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShootBullet(bool Left)
    {
        if(GameController.Bullets > 0)
        {
            if (Left)
            {
                GameObject temp = Instantiate<GameObject>(BulletObj);
                temp.transform.position = Turret.transform.position;
                var dir = temp.GetComponent<Bullet>();
                dir.InstantiateBullet(true);
            }
            else
            {
                GameObject temp = Instantiate<GameObject>(BulletObj);
                temp.transform.position = Turret.transform.position;
                var dir = temp.GetComponent<Bullet>();
                dir.InstantiateBullet(false);
            }
            GameController.DecrementBulletCount(1);
            HitAudioSource.clip = HitAudioClip;
            HitAudioSource.Play();
        }
    }
}

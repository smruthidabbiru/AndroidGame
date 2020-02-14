using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHandler : MonoBehaviour
{

    public GameObject TargetObject;
    public Rigidbody2D CoinBody;
    public bool Diamond;
    public bool Red;
    public bool Green;
    public bool Yellow;
    public GameObject DiamondFX;
    public GameObject DiamondParticle;
    public GameObject RedParticle;
    public GameObject GreenParticle;
    public GameObject YellowParticle;
    public AudioClip Hitsound;
    public AudioSource HitSource;
    public int Band;
    float Step;
    // Start is called before the first frame update

    private void Awake()
    {

    }
    void Start()
    {
        HitSource = Camera.main.GetComponent<AudioSource>();
        TargetObject = GameObject.FindWithTag("TargetObject");
        CoinBody.gravityScale = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefs.GetInt("MusicMode") == 1)
        {
            Step = (GameController.MovementSpeed + (AudioSpectrumData._BandBuffer[Band] * 4)) * Time.deltaTime;
        }
        else
        {
            Step = GameController.MovementSpeed * Time.deltaTime;
        }
           
        if(Diamond)
        {
            Step = Step * 1.2f;
        }
        if(Red)
        {
            Step = Step * 0.9f;
        }
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x,TargetObject.transform.position.y,transform.position.z), Step);
        if(this.transform.position.y == TargetObject.transform.position.y)
        {
            Destroy(this.gameObject,0.0f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            HitSource.clip = Hitsound;
            HitSource.Play();
            if (Diamond)
            {
                Instantiate<GameObject>(DiamondParticle,transform.position,Quaternion.identity);
                Instantiate<GameObject>(DiamondFX, transform.position, Quaternion.identity);
            }
            if(Red)
            {
                GameController.DecrementBulletCount(2);
                Instantiate<GameObject>(DiamondFX, transform.position, Quaternion.identity);
                Instantiate<GameObject>(RedParticle, transform.position, Quaternion.identity);
                Handheld.Vibrate();

            }
            if(Green)
            {
                GameController.ImcrementBulletCount(3);
                Instantiate<GameObject>(DiamondFX, transform.position, Quaternion.identity);
                Instantiate<GameObject>(GreenParticle, transform.position, Quaternion.identity);
            }
            if(Yellow)
            {
                GameController.Yellow += 1;
                Instantiate<GameObject>(YellowParticle, transform.position, Quaternion.identity);
            }
            Destroy(this.gameObject, 0.0f);
            //Do stuff here for handling player data and EFFECTS
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
public class RandomSpawner : MonoBehaviour
{
    public float TimeIntervel = 0.5f;
    public GameObject[] SpawanableObjects;
    public Rect SpawnObjectRoot;
    public GameObject spawnTransform;
    public GameObject TransformLeft;
    public GameObject TransformRight;
    float spawnTime = 3.0f;
    public static bool StopGame = false;
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(SpawnObject());
    }
    // Update is called once per frame
    void Update()
    {
        if(StopGame == false)
        {
            spawnTime -= Time.deltaTime;
            if (spawnTime <= 0)
            {
                //StartCoroutine(SpawnObject());
                System.Random ran = new System.Random();
                System.Random RanObj = new System.Random();
                GameObject temp = Instantiate<GameObject>(SpawanableObjects[RanObj.Next(0, SpawanableObjects.Length)]);
                temp.transform.localScale = new Vector3(GameController.ScaleMode, GameController.ScaleMode, GameController.ScaleMode);
                temp.transform.position = new Vector3(Random.Range(TransformLeft.transform.position.x, TransformRight.transform.position.x), spawnTransform.transform.position.y, spawnTransform.transform.position.z);
                spawnTime = 1.5f;
            }
        }
        //StartCoroutine(SpawnObject());
    }

    IEnumerator SpawnObject()
    {
        System.Random ran = new System.Random();
        System.Random RanObj = new System.Random();
        GameObject temp = Instantiate<GameObject>(SpawanableObjects[RanObj.Next(0, SpawanableObjects.Length)]);
        temp.transform.localScale = new Vector3(GameController.ScaleMode, GameController.ScaleMode, GameController.ScaleMode);
        temp.transform.position = new Vector3(Random.Range(TransformLeft.transform.position.x, TransformRight.transform.position.x), spawnTransform.transform.position.y, spawnTransform.transform.position.z);
        yield return new WaitForSecondsRealtime(0.1f);
        //StartCoroutine(SpawnObject());
    }

}

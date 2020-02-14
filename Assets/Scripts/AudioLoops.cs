using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class AudioLoops : MonoBehaviour
{
    public AudioSource MainBGMAudio;
    public List<AudioClip> audioclips = new List<AudioClip>();
    int start = 0;

    // Start is called before the first frame update
    [System.Obsolete]
    void Start()
    {
        StartCoroutine(ChangeSong());
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator ChangeSong()
    {
        float length = audioclips[start].length;
        MainBGMAudio.clip = audioclips[start];
        Debug.Log(MainBGMAudio.clip.name);
        MainBGMAudio.Play();
        yield return new WaitForSecondsRealtime(length);
        start = start + 1;
        if (start == audioclips.Count-1)
        {
            start = 0;
        }
        StartCoroutine(ChangeSong());
    }
}

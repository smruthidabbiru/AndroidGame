using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Threading;
public class LoadSceneRetro : MonoBehaviour
{
    public AudioSource SongSource;
    public AudioClip MenuClip;
    public AudioClip LoadingClip;
    bool loadingScene = false;
    bool changeAudioCLip = false;
    private Coroutine loadingOperation;
    // Start is called before the first frame update
    void Start()
    {
        SongSource.clip = MenuClip;
        SongSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadTargetSceneMusic()
    {
        PlayerPrefs.SetInt("SceneNuber", 1);
        PlayerPrefs.SetInt("MusicMode", 1);
        SceneManager.LoadSceneAsync(PlayerPrefs.GetInt("SceneNumber"));
        SongSource.clip = LoadingClip;
        SongSource.Play();
    }
    public void LoadTargetSceneNormal()
    {
        PlayerPrefs.SetInt("SceneNuber", 1);
        PlayerPrefs.SetInt("MusicMode", 0);
        SceneManager.LoadSceneAsync(PlayerPrefs.GetInt("SceneNumber"));
        SongSource.clip = LoadingClip;
        SongSource.Play();
    }
    
    
}

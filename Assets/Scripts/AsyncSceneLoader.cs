using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class AsyncSceneLoader : MonoBehaviour
{
    float loadValue;
    public Slider LoadSlider;
    bool loadingScene = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!loadingScene)
        {
            loadingScene = true;
            StartCoroutine(LoadLevel());
        }
    }
    IEnumerator LoadLevel()
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(PlayerPrefs.GetInt("SceneNumber"));
        while(!async.isDone)
        {
            float progress = Mathf.Clamp01(async.progress / 0.9f);
            LoadSlider.value = progress;
            yield return null;
        }
    }
}

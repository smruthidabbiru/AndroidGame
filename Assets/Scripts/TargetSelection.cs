using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TargetSelection : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ButtonPressedMusic()
    {
        PlayerPrefs.SetInt("MusicMode", 1);
        PlayerPrefs.SetInt("SceneNumber", 1);
        SceneManager.LoadScene(2);
    }
    public void ButtonPressedNormal()
    {
        PlayerPrefs.SetInt("MusicMode", 0);
        PlayerPrefs.SetInt("SceneNumber", 1);
        SceneManager.LoadScene(2);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PauseHandle : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject PausePanel;
    public Sprite PauseSprite;
    public Sprite PlaySprite;
    public Button PauseButton;
    bool paused = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void pauseButtonPressed()
    {
        if(paused == true)
        {
            paused = false;
            RandomSpawner.StopGame = false;
            Time.timeScale = 1.0f;
            PauseButton.image.sprite = PauseSprite;
            PausePanel.SetActive(false);
        }
        else
        {
            paused = true;
            RandomSpawner.StopGame = true;
            Time.timeScale = 0.0f;
            PauseButton.image.sprite = PlaySprite;
            PausePanel.SetActive(true);
        }
    }
}

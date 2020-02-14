using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;

public class DiskFiles : MonoBehaviour
{
    public Slider QualitySlider;
    public Text HoghscoreText;
    public GameObject NickNameInput;
    public GameObject DoneButton;
    public Text Nickname;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
        QualitySlider.enabled = false;
        if(!Directory.Exists(Application.persistentDataPath+"/HighScore"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/HighScore");
            if(!File.Exists(Application.persistentDataPath + "/HighScore/Score.txt"))
            {
                File.Create(Application.persistentDataPath + "/HighScore/Score.txt").Close();
                File.WriteAllText(Application.persistentDataPath + "/HighScore/Score.txt", "0");
                Debug.Log("Score Creation Success");
            }
        }
        if (!Directory.Exists(Application.persistentDataPath + "/QualitySettings"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/QualitySettings");
            if (!File.Exists(Application.persistentDataPath + "/QualitySettings/Quality.txt"))
            {
                File.Create(Application.persistentDataPath + "/QualitySettings/Quality.txt").Close();
                File.WriteAllText(Application.persistentDataPath + "/QualitySettings/Quality.txt", "2");
                Debug.Log("Quality Settings creation complete");
            }
        }
        QualitySlider.enabled = true;
        QualitySlider.value = Convert.ToInt32(File.ReadAllText(Application.persistentDataPath + "/QualitySettings/Quality.txt"));
        HoghscoreText.text = "HighScore: " + File.ReadAllText(Application.persistentDataPath + "/HighScore/Score.txt");
        if(string.IsNullOrEmpty(PlayerPrefs.GetString("PlayerName")))
        {
            NickNameInput.SetActive(true);
            DoneButton.SetActive(true);
            File.WriteAllText(Application.persistentDataPath + "/HighScore/Score.txt", "0");
        }
        else
        {
            NickNameInput.SetActive(false);
            DoneButton.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetPlauerName()
    {
        PlayerPrefs.SetString("PlayerName", Nickname.text);
        NickNameInput.SetActive(false);
        DoneButton.SetActive(false);
    }
}

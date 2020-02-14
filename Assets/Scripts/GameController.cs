using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System;
public class GameController : MonoBehaviour
{
    public static int Bullets = 20;
    public static int Diamonds = 0;
    public Text DiamondText;
    public Text BulletText;
    public Text SpeedText;
    public Text YellowText;
    public GameObject Deathpanel;
    public static bool panelActive = false;
    public static float MovementSpeed = 1f;
    public float SpeedAdder = 0.2f;
    static float AddSpeed;
    public static float ScaleMode = 0.85f;
    static float SizeRedution;
    public float Scaller = 0.25f;
    public static int Yellow = 0;
    public Text TimerText;
    static int SnapShot;
    public static int target;
    static int TimeRemaining;
    bool CallCoroutine = false;
    public Text GameScoreText;
    public Text HighScoreText;
    public Button ButtonLeft;
    public Button ButtonRight;
    void Start()
    {
        Bullets = 20;
        Diamonds = 0;
        Yellow = 0;
        Time.timeScale = 1.0f;
        BulletText.text = Bullets.ToString();
        DiamondText.text = Diamonds.ToString();
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Application.targetFrameRate = -1;
        panelActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Bullets <= 0 && panelActive == false)
        {
            StartCoroutine(CheckForBullets());
            ButtonLeft.enabled = false;
            ButtonRight.enabled = false;
        }
    }

    public static void ImcrementBulletCount(int count)
    {
        Bullets = Bullets + count;
    }
    public static void IncrementDiamondCount(int count)
    {
        Diamonds = Diamonds + count;
        if (Diamonds % 10 == 0 && Diamonds != 0)
        {
            MovementSpeed = MovementSpeed + AddSpeed;
            //Bullets += Yellow * 3;
            //Yellow = 0;
            if (Diamonds <= 20)
            {
                ScaleMode = ScaleMode - SizeRedution;
            }
        }
    }
    public static void DecrementBulletCount(int count)
    {
        Bullets = Bullets - count;
    }
    private void LateUpdate()
    {
        BulletText.text = Bullets.ToString();
        //DiamondText.text = Diamonds.ToString() + " / " + target.ToString();
        YellowText.text = Yellow.ToString();
        SpeedText.text = "FPS: " + (1 / Time.deltaTime).ToString();
        AddSpeed = SpeedAdder;
        SizeRedution = Scaller;
    }
    public void GameMode()
    {
        PlayerPrefs.SetInt("SceneNumber", 1);
        SceneManager.LoadScene(2);
    }

    IEnumerator CheckForBullets()
    {
        yield return new WaitForSeconds(1.5f);
        if (Bullets <= 0)
        {
            Deathpanel.SetActive(true);
            panelActive = true;
            GameScoreText.text = Diamonds.ToString();
            if(Diamonds > Convert.ToInt32(File.ReadAllText(Application.persistentDataPath + "/HighScore/Score.txt")))
            {
                File.WriteAllText(Application.persistentDataPath + "/HighScore/Score.txt", Diamonds.ToString());
                HighScoreText.text = Diamonds.ToString();
            }
            else
            {
                HighScoreText.text = File.ReadAllText(Application.persistentDataPath + "/HighScore/Score.txt");
            }
            var dl = GetComponent<dreamloLeaderBoard>();
            dl.AddScore(PlayerPrefs.GetString("PlayerName"), Diamonds);
            Time.timeScale = 0.0f;
        }
        else
        {
            panelActive = false;
            ButtonLeft.enabled = true;
            ButtonRight.enabled = true;
        }
    }
}

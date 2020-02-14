using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BackDropSupport : MonoBehaviour
{
    public GameObject PianoTiles;
    public GameObject StaticBG;
    public BackgroundData[] BGs;
    public Image Background;
    public Image Streaks;
    bool changeBG = false;
    int start = 0;
    // Start is called before the first frame update
    void Start()
    {
        PianoTiles.SetActive(false);
        StaticBG.SetActive(false);
        if(PlayerPrefs.GetInt("MusicMode") == 1)
        {
            PianoTiles.SetActive(true);
        }
        else
        {
            StaticBG.SetActive(true);
            Background.sprite = BGs[start].BackGround;
            Background.color = BGs[start].SpreiteColor;
            Streaks.sprite = BGs[start].Streaks;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(GameController.Diamonds % 10 == 0 && changeBG == false)
        {
            start = start + 1;
            if(start + 1 >= BGs.Length)
            {
                start = 0;
            }
            Background.sprite = BGs[start].BackGround;
            Background.color = BGs[start].SpreiteColor;
            Streaks.sprite = BGs[start].Streaks;
            changeBG = true;
        }
        if(GameController.Diamonds %10 != 0)
        {
            changeBG = false;
        }
    }
}
[System.Serializable]
public class BackgroundData
{
    public Sprite BackGround;
    public Sprite Streaks;
    public Color SpreiteColor;
}
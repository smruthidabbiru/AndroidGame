using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
public class GetScores : MonoBehaviour
{
    public Text LeabText;
    dreamloLeaderBoard dl;
    string url = "http://dreamlo.com/lb/5df7c4e5b5622f683c6f99f0/pipe";
    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(SendPostCoroutine());

    }

    // Update is called once per frame
    void Update()
    {
       
    }
    IEnumerator SendPostCoroutine()
    {
        string uri = url;
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            if (webRequest.isNetworkError)
            {
                Debug.Log(pages[page] + ": Error: " + webRequest.error);
            }
            else
            {
                Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                if(string.IsNullOrEmpty(webRequest.downloadHandler.text))
                {
                    LeabText.text = "Be the first one to upload score";
                }
                else
                {
                    string[] lines = webRequest.downloadHandler.text.Split('\n');
                    for (int i = 0; i < 10; i++)
                    {
                        string[] content = lines[i].Split('|');
                        LeabText.text += (i + 1).ToString() + ".    " + content[0] + "    " + content[1] + "\n";
                    }
                }

            }
        }
    }

}

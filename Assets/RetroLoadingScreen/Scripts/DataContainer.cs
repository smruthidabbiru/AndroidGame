//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.SceneManagement;
//public class DataContainer : ScriptableObject
//{
//    // Start is called before the first frame update
//    public IEnumerator LoadLevelAsync()
//    {
//        AsyncOperation async = SceneManager.LoadSceneAsync(PlayerPrefs.GetInt("SceneNumber"));
//        while (!async.isDone)
//        {
//            yield return null;
//        }
//    }
//}

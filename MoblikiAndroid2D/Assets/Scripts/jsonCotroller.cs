using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using static BestScoreMenu;
using UnityEngine;

public class jsonCotroller : MonoBehaviour
{
    public static string jsonURL = "https://api.myjson.com/bins/137f1w";
    public static string jsontxt;
    public static string jsonToSend;
    public static bool canSend = false;
    public static bool canGet = true;
    public static bool received = false;

    IEnumerator getData()
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(jsonURL))
        {
            yield return webRequest.SendWebRequest();

            string[] pages = jsonURL.Split('/');
            int page = pages.Length - 1;

            if (webRequest.isNetworkError)
            {
                Debug.Log(pages[page] + ": Error: " + webRequest.error);
            }
            else
            {
                jsontxt = webRequest.downloadHandler.text;
                //Debug.Log(jsontxt);
                received = true;
            }
        }
    }

    private void Update()
    {
        if (canGet)
            StartCoroutine(getData());
        if (canSend)
            StartCoroutine(Upload());
    }


    IEnumerator Upload()
    {
        using (UnityWebRequest www = UnityWebRequest.Put(jsonURL, jsonToSend))
        {
            www.SetRequestHeader("Content-Type", "application/json; charset=utf-8");
            www.method = UnityWebRequest.kHttpVerbPUT;
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                //Debug.Log("Upload complete!");
                canSend = false;
            }
        }
    }
}

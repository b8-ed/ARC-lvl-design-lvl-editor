using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace LBProgramming
{
    public class LBWebManager : MonoBehaviour
    {
        private static LBWebManager instance = null;
        public static LBWebManager Instance
        {
            get
            {
                return instance;
            }
        }

        [RuntimeInitializeOnLoadMethod]
        public static void OnLoad()
        {
            Init();
        }

        public static void Init()
        {
            if(instance == null)
            {
                GameObject go = new GameObject("LBWebManager");
                instance = go.AddComponent<LBWebManager>();
                go.isStatic = true;
                DontDestroyOnLoad(go);
            }
        }

        public void UploadFileToUrl(string url, string jsonString)
        {
            StartCoroutine(UploadFile(url, jsonString));
        }

        IEnumerator UploadFile(string url, string jsonString)
        {
            List<IMultipartFormSection> formData = new List<IMultipartFormSection>();
            formData.Add(new MultipartFormDataSection("field1=foo&field2=bar"));
            formData.Add(new MultipartFormFileSection("my file data", "myfile.txt"));

            UnityWebRequest www = UnityWebRequest.Post("http://golstatsapisvr.azurewebsites.net/set_gameConfigVRLive", formData);
            yield return www.Send();

#if UNITY_5
            if(www.isError)
#else
            if(www.isNetworkError)
#endif
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Form upload complete!");
            }
            //WWWForm form = new WWWForm();
        }
    }
}


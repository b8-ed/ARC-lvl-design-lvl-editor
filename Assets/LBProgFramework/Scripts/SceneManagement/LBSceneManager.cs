using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LBProgramming
{
    public class LBSceneManager : MonoBehaviour
    {
        private static LBSceneManager instance = null;
        public static LBSceneManager Instance
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
            if (instance == null)
            {
                GameObject go = new GameObject("LBSceneManager");
                instance = go.AddComponent<LBSceneManager>();
                go.isStatic = true;
                DontDestroyOnLoad(go);
            }
        }

        public void LoadScene(string str_SceneName)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(str_SceneName);
        }

        public void LoadSceneAsync(string str_SceneName)
        {
            UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(str_SceneName);
        }

        public void LoadAfterTime(string str_SceneName, float time)
        {
            StartCoroutine(LoadScene(str_SceneName, time));
        }

        IEnumerator LoadScene(string sceneName, float time)
        {
            yield return new WaitForSeconds(time);

            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        }

    }
}


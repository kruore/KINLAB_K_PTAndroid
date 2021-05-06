using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
namespace _KINLAB
{
    public class SceneLoadingManager : MonoBehaviour
    {
        public static SceneLoadingManager instance = null;

        public string nextSceneName = string.Empty;

        public float delayTime = 0.0f;

        private void Awake()
        {
            instance = this;
        }

        private void Start()
        {
            StartCoroutine(DelayLoadScene());
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                SceneManager.LoadScene(nextSceneName);
            }
        }

        private IEnumerator DelayLoadScene()
        {
            if (delayTime != 0.0f)
            {
                if (nextSceneName != string.Empty)
                {
                    yield return new WaitForSeconds(delayTime);
                    SceneManager.LoadScene(nextSceneName);
                }
                else
                {
                    yield return new WaitForSeconds(delayTime);
                    Application.Quit();
                }
            }
            else
            {
                yield break;
            }
        }

        public void LoadNextScene(float _delay)
        {
            if(_delay != 0.0f)
            {
                StartCoroutine(LoadNextScene_Delay(_delay));
            }
            else
            {
                SceneManager.LoadScene(nextSceneName);
            }

        }

        private IEnumerator LoadNextScene_Delay(float _delay)
        {
            yield return new WaitForSeconds(_delay);
            SceneManager.LoadScene(nextSceneName);
            yield break;
        }
    }
}
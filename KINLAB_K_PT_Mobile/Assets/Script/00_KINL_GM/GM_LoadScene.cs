using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GM_LoadScene : MonoBehaviour
{
    public void LoadScene_K_PT_BodyTracking()
    {
        SceneManager.LoadScene("MLKIT/BlazePose/BlazePoseUpperBody");
    }
    public void LoadScene_K_PT_GameMode01()
    {
        SceneManager.LoadScene("MLKIT/BlazePose/TouchObject");
    }
    public void LoadScene_K_PT_BodyTracking_FullBody()
    {
        SceneManager.LoadScene("MLKIT/BlazePose/BlazePose_High");
    }

    public void LoadScene_K_PT()
    {
        SceneManager.LoadScene("00_KINLAB/01_Scene/20210501/00 KINL Experiment Title");
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "00_LoadScene")
        {
#if UNITY_ANDROID_API
            if (Input.touchCount == 2)
            {
                SceneManager.LoadScene("Scene/01_SceneSelector");
                // LoadScene_K_PT_BodyTracking_FullBody();
            }
#endif
#if UNITY_EDITOR
            if (Input.GetKeyDown(KeyCode.P))
            {
                SceneManager.LoadScene("Scene/01_SceneSelector");
                // LoadScene_K_PT_BodyTracking_FullBody();
            }
#endif
        }
    }
}

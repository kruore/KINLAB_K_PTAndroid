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

    private void Update()
    {
#if UNITY_ANDROID_API
        if (Input.touchCount==2)
        {
            LoadScene_K_PT_GameMode01();
           // LoadScene_K_PT_BodyTracking_FullBody();
        }
#endif
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.P))
        {
            LoadScene_K_PT_GameMode01();
           // LoadScene_K_PT_BodyTracking_FullBody();
        }
#endif
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
public class CameraPermission : MonoBehaviour
{
    void Start()
    {
#if UNITY_ANDROID
        //만약 카메라 퍼미션이 참이 아니면
        //HasUserAuthorizedPermission(Permission.권한) 함수는 true false 를 반환함.
        if (!Permission.HasUserAuthorizedPermission(Permission.Camera))
        {
            Permission.RequestUserPermission(Permission.Camera);
        }
    }
#endif
}
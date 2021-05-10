using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
public class CameraPermission : MonoBehaviour
{

#if UNITY_ANDROID
void Start()    
{
        //???? ?????? ???????? ???? ??????
        //HasUserAuthorizedPermission(Permission.????) ?????? true false ?? ??????.
        if (!Permission.HasUserAuthorizedPermission(Permission.Camera))
        {
            Permission.RequestUserPermission(Permission.Camera);
        }
    }
#endif
}
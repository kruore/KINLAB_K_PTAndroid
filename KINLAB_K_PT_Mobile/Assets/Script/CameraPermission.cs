using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
public class CameraPermission : MonoBehaviour
{
    void Start()
    {
#if UNITY_ANDROID
        //���� ī�޶� �۹̼��� ���� �ƴϸ�
        //HasUserAuthorizedPermission(Permission.����) �Լ��� true false �� ��ȯ��.
        if (!Permission.HasUserAuthorizedPermission(Permission.Camera))
        {
            Permission.RequestUserPermission(Permission.Camera);
        }
    }
#endif
}
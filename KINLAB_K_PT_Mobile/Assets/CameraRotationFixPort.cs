using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotationFixPort : MonoBehaviour
{
    public void ClickPortable()
    {
        Screen.SetResolution(1080, 2280, true);
        Screen.orientation = ScreenOrientation.Portrait;
        Screen.autorotateToPortrait = true;
        Screen.autorotateToPortraitUpsideDown = true;
        Screen.autorotateToLandscapeLeft = false;
        Screen.autorotateToLandscapeRight = false;

    }
}

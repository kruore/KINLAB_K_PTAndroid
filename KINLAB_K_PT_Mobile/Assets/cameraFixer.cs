using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFixer : MonoBehaviour
{
    private void Awake()
    {
            Screen.SetResolution(1080, 2280, true);
            Screen.orientation = ScreenOrientation.Portrait;
            Screen.autorotateToPortrait = true;
            Screen.autorotateToPortraitUpsideDown = true;
            Screen.autorotateToLandscapeLeft = false;
            Screen.autorotateToLandscapeRight = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TensorFlowLite;
using Cysharp.Threading.Tasks;

/// <summary>
/// BlazePose form MediaPipe
/// https://github.com/google/mediapipe
/// https://viz.mediapipe.dev/demo/pose_tracking
/// </summary>
public sealed class BlazePoseSample : MonoBehaviour
{
    public enum Mode
    {
        UpperBody,
        FullBody,
    }

    public enum GameMode
    {
        BodyTracking,
        TouchReaction,
        NotStarted,
        GameEnd
    }

    public static BlazePoseSample instance;

    [SerializeField, FilePopup("*.tflite")] string poseDetectionModelFile = "coco_ssd_mobilenet_quant.tflite";
    [SerializeField, FilePopup("*.tflite")] string poseLandmarkModelFile = "coco_ssd_mobilenet_quant.tflite";
    [SerializeField] Mode mode = Mode.UpperBody;
    [SerializeField] public GameMode gameMode;
    [SerializeField] RawImage cameraView = null;
    [SerializeField] RawImage debugView = null;
    [SerializeField] bool useLandmarkFilter = true;
    [SerializeField, Range(2f, 30f)] float filterVelocityScale = 10;
    [SerializeField] bool runBackground;

    WebCamTexture webcamTexture;
    PoseDetect poseDetect;
    PoseLandmarkDetect poseLandmark;


    //CHECK HUMAN BODY
    public GameObject humanbodyRoot;
    public GameObject[] humanbody;

    Vector3[] rtCorners = new Vector3[4]; // just cache for GetWorldCorners
    Vector3[] worldJoints;
    PrimitiveDraw draw;
    PoseDetect.Result poseResult;
    PoseLandmarkDetect.Result landmarkResult;
    UniTask<bool> task;
    CancellationToken cancellationToken;

    public bool ColorLineDrow_DebugMode = false;
    public Toggle ColorLineDrow_DebugerToggle;
    public GameObject Drow_DebugLine;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            this.transform.position = new Vector3(0f, 0f, -10f);
        }
        else
        {
            Destroy(this.gameObject);
        }
        this.transform.position = new Vector3(0f, 0f, -10f);
    }
    void Start()
    {

        // Init model
        string detectionPath = Path.Combine(Application.streamingAssetsPath, poseDetectionModelFile);
        string landmarkPath = Path.Combine(Application.streamingAssetsPath, poseLandmarkModelFile);


        WebCamDevice[] devices = WebCamTexture.devices;
        string camName = string.Empty;
        // 사용할 카메라를 선택
        // 가장 처음 검색되는 전면 카메라 사용
        int selectedCameraIndex = -1;
        for (int i = 0; i < devices.Length; i++)
        {
            // 사용 가능한 카메라 로그
            Debug.Log("Available Webcam: " + devices[i].name + ((devices[i].isFrontFacing) ? "(Front)" : "(Back)"));
            //    text01.text = ("Available Webcam Count = " + i.ToString());

            // 전면 카메라인지 체크
            if (devices[i].isFrontFacing == true)
            {
                //   text02.text = camName = devices[i].name + "i = " + i.ToString(); ;
                camName = devices[i].name;
                // 해당 카메라 선택
                selectedCameraIndex = i;
                break;
            }
        }
        //// Init camera 
        //string cameraName = WebCamUtil.FindName(new WebCamUtil.PreferSpec()
        //{
        //    isFrontFacing = false,
        //    kind = WebCamKind.WideAngle,
        //});
        switch (mode)
        {
            case Mode.UpperBody:
                poseDetect = new PoseDetectUpperBody(detectionPath);
                poseLandmark = new PoseLandmarkDetectUpperBody(landmarkPath);
                webcamTexture = new WebCamTexture(camName, 2280, 1080, 30);
                Screen.orientation = ScreenOrientation.LandscapeRight;
                Screen.SetResolution(1080, 2280, true);
                break;
            case Mode.FullBody:
                poseDetect = new PoseDetectFullBody(detectionPath);
                poseLandmark = new PoseLandmarkDetectFullBody(landmarkPath);
                webcamTexture = new WebCamTexture(camName, 1080, 2280, 30);
                break;
            default:
                throw new System.NotSupportedException($"Mode: {mode} is not supported");
        }
        cameraView.texture = webcamTexture;
        webcamTexture.Play();
        Debug.Log($"Starting camera: {camName}");

        draw = new PrimitiveDraw(Camera.main, gameObject.layer);
        worldJoints = new Vector3[poseLandmark.JointCount];

        humanbody = new GameObject[humanbodyRoot.transform.childCount];

        cancellationToken = this.GetCancellationTokenOnDestroy();
        for (int i = 0; i < humanbodyRoot.transform.childCount; i++)
        {
            humanbody[i] = humanbodyRoot.transform.GetChild(i).gameObject;
        }

    }

    void OnDestroy()
    {
        webcamTexture?.Stop();
        poseDetect?.Dispose();
        poseLandmark?.Dispose();
        draw?.Dispose();
    }

    void Update()
    {
        if (runBackground)
        {
            if (task.Status.IsCompleted())
            {
                task = InvokeAsync();
            }
        }
        else
        {
            Invoke();
        }

        if (poseResult == null || poseResult.score < 0f) return;

        //if (ColorLineDrow_DebugMode)
        //{
        //  //  DrawFrame(poseResult);
        //}

        if (landmarkResult == null || landmarkResult.score < 0.2f) return;

        switch (gameMode)
        {
            case GameMode.BodyTracking:
                if (ColorLineDrow_DebugMode)
                {
                    DrawFrame(poseResult);
                    DrawCropMatrix(poseLandmark.CropMatrix);
                    DrawJoints(landmarkResult.joints);
                    //lineColor
                    if (GM_PosManager.instance.lineColor[0].color == Color.red)
                    {
                        for (int i = 0; i < GM_PosManager.instance.linecontainer.gameObject.transform.childCount; i++)
                        {
                            GM_PosManager.instance.lineColor[i].color = Color.green;
                        }
                    }
                }
                else
                {
                    //  DrawCropMatrix(poseLandmark.CropMatrix);
                    DrawJoints(landmarkResult.joints);
                    //lineColor
                    if (GM_PosManager.instance.lineColor[0].color == Color.red)
                    {
                        for (int i = 0; i < GM_PosManager.instance.linecontainer.gameObject.transform.childCount; i++)
                        {
                            GM_PosManager.instance.lineColor[i].color = Color.green;
                        }
                    }
                }
                break;

            case GameMode.TouchReaction:
                if (ColorLineDrow_DebugMode)
                {
                    DrawFrame(poseResult);
                    DrawCropMatrix(poseLandmark.CropMatrix);
                    DrawJoints(landmarkResult.joints);
                    if (GM_Touchreaction.instance.lineColor[0].color == Color.red)
                    {
                        for (int i = 0; i < GM_Touchreaction.instance.linecontainer.gameObject.transform.childCount; i++)
                        {
                            GM_Touchreaction.instance.lineColor[i].color = Color.green;
                        }
                    }

                }
                else
                {
                    //  DrawCropMatrix(poseLandmark.CropMatrix);
                    DrawJoints(landmarkResult.joints);
                    if (GM_Touchreaction.instance.lineColor[0].color == Color.red)
                    {
                        for (int i = 0; i < GM_Touchreaction.instance.linecontainer.gameObject.transform.childCount; i++)
                        {
                            GM_Touchreaction.instance.lineColor[i].color = Color.green;
                        }
                    }
                }
                break;
            case GameMode.NotStarted:
                Time.timeScale = 0;
                break;
            case GameMode.GameEnd:
                Time.timeScale = 0;
                break;
            default:
                throw new System.NotSupportedException($"Mode: {gameMode} is not supported");
        }
    }
    void DrawFrame(PoseDetect.Result pose)
    {
        Vector3 min = rtCorners[0];
        Vector3 max = rtCorners[2];

        draw.color = Color.green;

        draw.Rect(MathTF.Lerp(min, max, pose.rect, true), 0.02f, min.z);

        foreach (var kp in pose.keypoints)
        {
            draw.Point(MathTF.Lerp(min, max, (Vector3)kp, true), 0.05f);
        }
        draw.Apply();
    }

    void DrawCropMatrix(in Matrix4x4 matrix)
    {
        draw.color = Color.red;

        Vector3 min = rtCorners[0];
        Vector3 max = rtCorners[2];

        var mtx = WebCamUtil.GetMatrix(-webcamTexture.videoRotationAngle, false, webcamTexture.videoVerticallyMirrored)
            * matrix.inverse;
        Vector3 a = MathTF.LerpUnclamped(min, max, mtx.MultiplyPoint3x4(new Vector3(0, 0, 0)));
        Vector3 b = MathTF.LerpUnclamped(min, max, mtx.MultiplyPoint3x4(new Vector3(1, 0, 0)));
        Vector3 c = MathTF.LerpUnclamped(min, max, mtx.MultiplyPoint3x4(new Vector3(1, 1, 0)));
        Vector3 d = MathTF.LerpUnclamped(min, max, mtx.MultiplyPoint3x4(new Vector3(0, 1, 0)));

        draw.Quad(a, b, c, d, 0.02f);
        draw.Apply();
    }

    void DrawJoints(Vector3[] joints)
    {
        // Apply webcam rotation to draw landmarks correctly
        Matrix4x4 mtx = WebCamUtil.GetMatrix(-webcamTexture.videoRotationAngle, false, webcamTexture.videoVerticallyMirrored);
        Vector3 min = rtCorners[0];
        Vector3 max = rtCorners[2];

        draw.color = Color.blue;

        // Update world joints
        for (int i = 0; i < joints.Length; i++)
        {
            var p = mtx.MultiplyPoint3x4(joints[i]);
            p = MathTF.Lerp(min, max, p);
            worldJoints[i] = p;
        }

        // Draw
        for (int i = 0; i < worldJoints.Length; i++)
        {
            if (ColorLineDrow_DebugMode)
            {
                draw.Cube(worldJoints[i], 0.2f);
            }
            humanbody[i].transform.position = worldJoints[i];
        }
        if (ColorLineDrow_DebugMode)
        {
            var connections = poseLandmark.Connections;
            for (int i = 0; i < connections.Length; i += 2)
            {
                draw.Line3D(
                    worldJoints[connections[i]],
                    worldJoints[connections[i + 1]],
                    0.05f);
            }
        }

        draw.Apply();
    }
    void Invoke()
    {
        poseDetect.Invoke(webcamTexture);
        cameraView.material = poseDetect.transformMat;
        cameraView.rectTransform.GetWorldCorners(rtCorners);

        poseResult = poseDetect.GetResults(0.7f, 0.3f);
        if (poseResult.score < 0) return;

        poseLandmark.Invoke(webcamTexture, poseResult);
        debugView.texture = poseLandmark.inputTex;

        if (useLandmarkFilter)
        {
            poseLandmark.FilterVelocityScale = filterVelocityScale;
        }
        landmarkResult = poseLandmark.GetResult(useLandmarkFilter);
    }

    async UniTask<bool> InvokeAsync()
    {
        // Note: `await` changes PlayerLoopTiming from Update to FixedUpdate.
        poseResult = await poseDetect.InvokeAsync(webcamTexture, cancellationToken, PlayerLoopTiming.FixedUpdate);

        if (poseResult.score < 0) return false;

        if (useLandmarkFilter)
        {
            poseLandmark.FilterVelocityScale = filterVelocityScale;
        }
        landmarkResult = await poseLandmark.InvokeAsync(webcamTexture, poseResult, useLandmarkFilter, cancellationToken, PlayerLoopTiming.Update);

        // Back to the update timing from now on 
        if (cameraView != null)
        {
            cameraView.material = poseDetect.transformMat;
            cameraView.rectTransform.GetWorldCorners(rtCorners);
        }
        if (debugView != null)
        {
            debugView.texture = poseLandmark.inputTex;
        }
        return true;
    }

    public void Debuger_Switch()
    {
        switch(gameMode)
        {
            case GameMode.BodyTracking:
                if (!ColorLineDrow_DebugMode)
                {
                    ColorLineDrow_DebugerToggle.isOn = true;
                    ColorLineDrow_DebugMode = true;
                    for (int i = 0; i < Drow_DebugLine.GetComponent<GM_PosManager>().transform.childCount; i++)
                    {
                        Drow_DebugLine.GetComponent<GM_PosManager>().transform.GetChild(i).gameObject.GetComponent<MeshRenderer>().enabled = true;
                    }
                }
                else
                {
                    ColorLineDrow_DebugerToggle.isOn = false;
                    ColorLineDrow_DebugMode = false;
                    for (int i = 0; i < Drow_DebugLine.GetComponent<GM_PosManager>().transform.childCount; i++)
                    {
                        Drow_DebugLine.GetComponent<GM_PosManager>().transform.GetChild(i).gameObject.GetComponent<MeshRenderer>().enabled = false;
                    }
                }
                break;
            case GameMode.TouchReaction:
                if (!ColorLineDrow_DebugMode)
                {
                    ColorLineDrow_DebugerToggle.isOn = true;
                    ColorLineDrow_DebugMode = true;
                }
                else
                {
                    ColorLineDrow_DebugerToggle.isOn = false;
                    ColorLineDrow_DebugMode = false;
                }
                break;
            case GameMode.NotStarted:
                Time.timeScale = 0;
                break;
            case GameMode.GameEnd:
                Time.timeScale = 0;
                break;
        }
     
    }
}

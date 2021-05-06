using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using System.Collections;
#if(UNITY_2018_3_OR_NEWER && UNITY_ANDROID)
using UnityEngine.Android;
#endif

/// <summary>
///    TestHome serves a game controller object for this application.
/// </summary>
public class Agora_Accessor : MonoBehaviour
{
    private static Agora_Accessor instance = null;

    // Use this for initialization
#if (UNITY_2018_3_OR_NEWER && UNITY_ANDROID)
    private ArrayList permissionList = new ArrayList();
#endif
    static Agora_Streammer app = null;

    //private string HomeSceneName = "SceneHome";

    //private string PlaySceneName = "SceneHelloVideo";

    // PLEASE KEEP THIS App ID IN SAFE PLACE
    // Get your own App ID at https://dashboard.agora.io/
    [SerializeField]
    private string AppID = "your_appid";

    [SerializeField]
    private GameObject videoScreen_Pref;
    public GameObject VideoScreen_Pref { get { return videoScreen_Pref; } }

    void Awake()
    {
#if (UNITY_2018_3_OR_NEWER && UNITY_ANDROID)
		permissionList.Add(Permission.Microphone);         
		permissionList.Add(Permission.Camera);
#endif

        // keep this alive across scenes

        if(instance = null)
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        CheckAppId();
    }

    void Update()
    {
        CheckPermissions();
    }

    private void CheckAppId()
    {
        Debug.Assert(AppID.Length > 10, "Please fill in your AppId first on Game Controller object.");
    }

    /// <summary>
    ///   Checks for platform dependent permissions.
    /// </summary>
    private void CheckPermissions()
    {
#if (UNITY_2018_3_OR_NEWER && UNITY_ANDROID)
        foreach(string permission in permissionList)
        {
            if (!Permission.HasUserAuthorizedPermission(permission))
            {                 
				Permission.RequestUserPermission(permission);
			}
        }
#endif
    }

    public void onJoinButtonClicked()
    {
        // get parameters (channel name, channel profile, etc.)
        GameObject go = GameObject.Find("ChannelName");
        InputField field = go.GetComponent<InputField>();

        // create app if nonexistent
        if (ReferenceEquals(app, null))
        {
            app = new Agora_Streammer(); // create app
            app.loadEngine(AppID); // load engine
        }

        // join channel and jump to next scene
        app.join(field.text);

        //SceneManager.sceneLoaded += OnLevelFinishedLoading; // configure GameObject after scene is loaded
        //SceneManager.LoadScene(PlaySceneName, LoadSceneMode.Single);
        ONLevelFinishedLoading();
    }

    public void onLeaveButtonClicked()
    {
        if (!ReferenceEquals(app, null))
        {
            app.leave(); // leave channel
            app.unloadEngine(); // delete engine
            app = null; // delete app
            //SceneManager.LoadScene(HomeSceneName, LoadSceneMode.Single);
        }
        //Destroy(gameObject);
    }

    //public void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    public void ONLevelFinishedLoading()
    {
        //if (scene.name == PlaySceneName)
        {
            if (!ReferenceEquals(app, null))
            {
                app.onSceneHelloVideoLoaded(); // call this after scene is loaded
            }
            //SceneManager.sceneLoaded -= OnLevelFinishedLoading;
        }
    }

    void OnApplicationPause(bool paused)
    {
        if (!ReferenceEquals(app, null))
        {
            app.EnableVideo(paused);
        }
    }

    void OnApplicationQuit()
    {
        if (!ReferenceEquals(app, null))
        {
            app.unloadEngine();
        }
    }

}

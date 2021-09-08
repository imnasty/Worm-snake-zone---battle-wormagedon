using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Compilation;
using System.IO;
using UnityEditor.Build.Reporting;
using System.Diagnostics;
using System;

[ExecuteInEditMode]
[CustomEditor(typeof(prefabss))]
[AddComponentMenu("Transform/Follow Transform")]

public class test : Editor
{
    bool toogleGooglePlay = true;
    bool toogleIOS = false;
    public string[] options = new string[] { "Cube", "Sphere", "Plane" };
    public int index;
    bool toogleHuawei = false;
    GameObject tessst;
    public string askerads_url;
    public string Webdav_server = "https://webdav.yandex.ru";
    ScreenshotHandler ss;
    private Resolution[] ssss;
    public string[] protokol3 = new string[] { "Yandex", "Google", "Mail" };
    public string[] Platform = new string[] { "Google", "UDP", "IOS" };
    public string[] scenes = new string[] { "00_Title Scene", "01_Main Scene", "CarouselScene" };
    // public GameObject myPrefab;
    static int platformint = 0;
    static string[] scenss;
    static string builddddd;
    public string Generatorname;
    public static string platrofmst;
    public static string BuildFolder;
    public static bool scene = false;
    public static bool scene1 = false;
    public static bool scene2 = false;
    public static bool checkbuilds = false;

    public static UnityEngine.Object Find(string name, System.Type type)
    {
        UnityEngine.Object[] objects = Resources.FindObjectsOfTypeAll(type);
        foreach (var obj in objects)
        {
            if (obj.name == name)
            {
                return obj;
            }
        }
        return null;

    }
    public static GameObject Find(string name)
    {
        return Find(name, typeof(GameObject)) as GameObject;
    }
    public override void OnInspectorGUI()
    {
        Drawcarusel();
        DrawDebugAsset();
        DrawAskerAds();

        //Debug.LogError(BuildFolder+"/"+Application.productName+".apk");

        DrawFeedback();
        DrawPlayfab();
        DrawGenerator();
        if (GUILayout.Button("Test OS"))
        {
            UnityEngine.Debug.Log(Environment.OSVersion.ToString());
            pathIO();
        }
        

    }
    public static void Autogit()
    {
            string os = Environment.OSVersion.ToString();
            string need_os = "Microsoft";
            if (os.Contains(need_os))
            {
                UnityEngine.Debug.Log("windows");
            Process.Start("G:\\Test.bat");
            }
         //   Process.Start("cmd.exe");
    }
    private void OnInspectorUpdate()
    {
        UnityEngine.Debug.Log("inspector update");
    }
    private void Update()
    {
        UnityEngine.Debug.Log("wad");
    }
    private void OnGUI()
    {
    }
    private void ScreenSettingss()
    {
        tessst = GameObject.Find("ScreenManager");
        ss = tessst.GetComponent<ScreenshotHandler>();
        ssss = ss.Resolutions;
        for (int i = 0; i < ssss.Length; i++)
        {
            UnityEngine.Debug.Log(ssss[i].Width.ToString());
            UnityEngine.Debug.Log(ssss[i].Height.ToString());

        }

    }


    [MenuItem("Askerweb/Debug_Manager2", false, 2)]
    [MenuItem("GameObject/Askerweb/Debug_Manager2", false, 3)]
    public static void Instant()
    {
        var DebugManager = new GameObject();
        DebugManager.name = "Debug Manager";
        DebugManager.AddComponent<prefabss>();
        DebugManager.AddComponent<qwertyu>();
        Selection.activeGameObject = DebugManager;
    }

    private void Save()
    {
        if (toogleGooglePlay == true)
        {
            toogleIOS = false;
            toogleHuawei = false;
            PlayerPrefs.SetString("CurrentSwitchPlatform", "Google");
            UnityEngine.Debug.Log(PlayerPrefs.GetString("CurrentSwitchPlatform"));
        }
        if (toogleIOS == true)
        {
            toogleGooglePlay = false;
            toogleHuawei = false;
            PlayerPrefs.SetString("CurrentSwitchPlatform", "IOS");
            UnityEngine.Debug.Log(PlayerPrefs.GetString("CurrentSwitchPlatform"));
        }

        if (toogleHuawei == true)
        {
            toogleIOS = false;
            toogleGooglePlay = false;
            PlayerPrefs.SetString("CurrentSwitchPlatform", "Huawei");
            UnityEngine.Debug.Log(PlayerPrefs.GetString("CurrentSwitchPlatform"));
        }
    }
    private void Drawcarusel()
    {
        GUILayout.Label("Билд для платформы:");
        toogleGooglePlay = EditorGUILayout.ToggleLeft("   Google play", toogleGooglePlay);
        if (toogleGooglePlay == true)
        {
            toogleIOS = false;
            toogleHuawei = false;
        }
        toogleIOS = EditorGUILayout.ToggleLeft("   IOS", toogleIOS);

        if (toogleIOS == true)
        {
            toogleGooglePlay = false;
            toogleHuawei = false;
        }
        toogleHuawei = EditorGUILayout.ToggleLeft("   Huawei", toogleHuawei);
        if (toogleHuawei == true)
        {
            toogleIOS = false;
            toogleGooglePlay = false;
        }
        EditorGUILayout.Space();
        if (GUILayout.Button("Применить"))
        {
            Save();
        }
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.Space();
    }
    public void DrawDebugAsset()
    {
        GUILayout.Label("Debug_Asset (консоль,скриншоты,версия)");
        EditorGUILayout.Space();
        GUILayout.Label("Протокол кодключения");
        EditorGUILayout.Separator();
        GUILayout.Label("ВНИМАНИЕ! ЗНАЧЕНИЕ В ПОЛЕ НИЖЕ СТОИТ ПО УМОЛЧАНИЮ, ОНО НЕ ТАКОЕ");
        GUILayout.Label("КАК СЕЙЧАС, ЕСЛИ ВЫ ХОТИТЕ ИЗМЕНИТЬ ЕГО, ВЫБЕРИТЕ И НАЖМИТЕ");
        GUILayout.Label("ПРИМЕНИТЬ");

        EditorGUILayout.Separator();

        index = EditorGUILayout.Popup(index, protokol3);
        //  selectedprotokol= EditorGUILayout.Popup("Webdav Protokol",selectedprotokol,protokol);
        // Webdav_server=GUILayout.TextField(Webdav_server);
        GUILayout.BeginHorizontal();

        if (GUILayout.Button("Применить"))
        {
            //Debug.Log(index.ToString());
            switch (index)
            {
                case 0:
                    qwertyu.instance.Server("https://webdav.yandex.ru");
                    break;
                case 1:
                    qwertyu.instance.Server("https://dav-pocket.appspot.com/docso");
                    break;
                case 2:
                    qwertyu.instance.Server("https://webdav.cloud.mail.ru");
                    break;
                default:
                    UnityEngine.Debug.LogError("Unrecognized Option");
                    break;
            }
            //qwertyu.instance.Server(Webdav_server);
        }
        if (GUILayout.Button("Вернуть исходное значение"))
        {
            qwertyu.instance.Server("https://webdav.yandex.ru");
        }
        GUILayout.EndHorizontal();
        if (GUILayout.Button("Накинуть"))
        {
            GameObject canvas = GameObject.Find("Canvas");
            if (GameObject.Find("DebugObject") == null)
            {
                GameObject DebugObjects = PrefabUtility.InstantiatePrefab(AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Debug_Asset/DebugObject.prefab") as GameObject) as GameObject;
            }
            if (GameObject.Find("Debug") == null)
            {
                GameObject Debug = PrefabUtility.InstantiatePrefab(AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Debug_Asset/Debug.prefab") as GameObject, canvas.transform) as GameObject;
                var script = Debug.GetComponent<version>();
                script.FindCanvass();
            }

            //script.CanvasScreen=GameObject.Find("CanvasScreen");
            //script.CanvasConsole=GameObject.Find("IngameDebugConsole");
        }
        if (GUILayout.Button("Удалить"))
        {
            GameObject Debug = Find("Debug");
            GameObject DebugObject = Find("DebugObject");
            if (Debug != null)
            {
                DestroyImmediate(Debug,true);
            }
            if (DebugObject != null)
            {
                DestroyImmediate(DebugObject,true);
            }
        }
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.Space();
    }
    public void DrawAskerAds()
    {
        GUILayout.Label("Asker_ads (наша реклама)");
        //
        GUILayout.Label("Прямая ссылка на файл нашего трейлера");

        askerads_url = GUILayout.TextField(askerads_url);
        GUILayout.BeginHorizontal();

        if (GUILayout.Button("Применить"))
        {
            qwertyu.instance.URL(askerads_url);
        }
        if (GUILayout.Button("Вернуть исходное значение"))
        {
            qwertyu.instance.URL("https://drive.google.com/uc?export=download&id=1YHasUqUw2EHGic-wfAq1a8IKBy_q-Jiu");
        }
        GUILayout.EndHorizontal();
        if (GUILayout.Button("Накинуть"))
        {   //GameObject ads = GameObject.Find("Askerads")
            if (GameObject.Find("Askerads") == null)
            {
                GameObject canvas = GameObject.Find("Canvas");
                GameObject askerads = PrefabUtility.InstantiatePrefab(AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Debug_Asset/Askerads/Prefabs/Askerads.prefab") as GameObject, canvas.transform) as GameObject;
                if (EditorUtility.DisplayDialog("Выбор режима настройки",
                    "Игра производная от ракетки или совершенно иная? Если вы нажмете да, параметры загрузятся сами, если нет, вам необходимо накинуть панель пройгрыша на объект askerads", "Да, накинуть автоматически", "Нет, вручную"))
                {
                    var script = askerads.GetComponent<Show>();
                    script.gameoversscreen = Find("GameOverPanel");
                }
            }
        }

        if (GUILayout.Button("Удалить"))
        {
            if (GameObject.Find("Askerads") != null)
            {
                DestroyImmediate(GameObject.Find("Askerads"));
            }
        }
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.Space();
    }

    public void DrawGenerator()
    {
        GUILayout.Label("Сборка АПК");
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        GUILayout.Label("Выберите платформу распространения");
        platformint = EditorGUILayout.Popup(platformint, Platform);
        BuildFolder = GUILayout.TextField(BuildFolder);
        if (GUILayout.Button("Выбрать папку"))
        {
            BuildFolder = EditorUtility.OpenFolderPanel("Folder for build game", "", "");
        }

        if (GUILayout.Button("Build"))
        {
            Build();
        }
        GUILayout.BeginVertical();
        scene = EditorGUILayout.ToggleLeft("   00_Title Scene", scene);
        scene1 = EditorGUILayout.ToggleLeft("   01_Main Scene", scene1);
        scene2 = EditorGUILayout.ToggleLeft("   CarouselScene", scene2);

        GUILayout.EndVertical();


        if (GUILayout.Button("Загрузить параметры прошлого билда"))
        {
            GetBuildSetting();
        }

    }
    public static void savescenes()
    {
        if (scene == true && scene1 == false && scene2 == false)
        {
            scenss = new[] { "Assets/Boom Boom Rocket/Scenes/00_Title Scene.unity" };
        }
        else if (scene == true && scene1 == true && scene2 == false)
        {
            scenss = new[] { "Assets/Boom Boom Rocket/Scenes/00_Title Scene.unity", "Assets/Boom Boom Rocket/Scenes/01_Main Scene.unity" };
        }
        else if (scene == true && scene1 == true && scene2 == true)
        {
            scenss = new[] { "Assets/Boom Boom Rocket/Scenes/00_Title Scene.unity", "Assets/Boom Boom Rocket/Scenes/01_Main Scene.unity", "Assets/CarouselGames/Scene/CarouselScene.unity" };
        }
        else if (scene == false && scene1 == true && scene2 == false)
        {
            scenss = new[] { "Assets/Boom Boom Rocket/Scenes/01_Main Scene.unity" };
        }
        else if (scene == false && scene1 == true && scene2 == true)
        {
            scenss = new[] { "Assets/Boom Boom Rocket/Scenes/01_Main Scene.unity", "Assets/CarouselGames/Scene/CarouselScene.unity" };
        }
        else if (scene == false && scene1 == false && scene2 == true)
        {
            scenss = new[] { "Assets/CarouselGames/Scene/CarouselScene.unity" };
        }
        else if (scene == true && scene1 == false && scene2 == true)
        {
            scenss = new[] { "Assets/Boom Boom Rocket/Scenes/00_Title Scene.unity", "Assets/CarouselGames/Scene/CarouselScene.unity" };
        }
        else
        {
            scenss = new[] { "" };
        }



    }
    public static void checkbuild()
    {
        if (Directory.Exists(BuildFolder))
        {
            if (scenss[0] != "")
            {
                checkbuilds = true;
                
            }
            else
            {
                checkbuilds = false;
                UnityEngine.Debug.LogError("Выберите хоть одну сцену");
            }
        }
        else
        {
            checkbuilds = false;
            UnityEngine.Debug.LogError("Неверный путь");
        }
    }
    public static void SaveBuildSetting()
    {
        EditorPrefs.SetInt(Application.productName + platformint.ToString(), platformint);
        EditorPrefs.SetBool(Application.productName + "scene", scene);
        EditorPrefs.SetBool(Application.productName + "scene1", scene1);
        EditorPrefs.SetBool(Application.productName + "scene2", scene2);
        EditorPrefs.SetString(Application.productName + " buildfolder", BuildFolder);
    }
    public void pathIO()
    {
        string path = BuildFolder;
//string subpath = "";
DirectoryInfo dirInfo = new DirectoryInfo(path);
if (!dirInfo.Exists)
{
    dirInfo.Create();
}
dirInfo.CreateSubdirectory(Application.productName.ToString());
    }
    public void GetBuildSetting()
    {
        platformint = EditorPrefs.GetInt(Application.productName + " platformint");
        scene = EditorPrefs.GetBool(Application.productName + "scene");
        scene1 = EditorPrefs.GetBool(Application.productName + "scene1");
        scene2 = EditorPrefs.GetBool(Application.productName + "scene2");
        BuildFolder = EditorPrefs.GetString(Application.productName + " buildfolder");
    }
    [MenuItem("Askerweb/Build", false, 2)]
    public static void Build()
    {


        savescenes();
        checkbuild();
        builddddd = BuildFolder + "/"+Application.productName.ToString()+"/"+ Application.productName +" v"+Application.version.ToString()+ ".apk";
        // BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
        // buildPlayerOptions.scenes = sceness


        PlayerSettings.bundleVersion = (int.Parse(PlayerSettings.bundleVersion) + 1).ToString();//версия приложения поддерживает точку
        PlayerSettings.Android.bundleVersionCode = PlayerSettings.Android.bundleVersionCode + 1;//версия кода только цифра
        if (checkbuilds == true)
        {
            BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
            buildPlayerOptions.scenes = scenss;
            buildPlayerOptions.locationPathName = builddddd;
            buildPlayerOptions.target = BuildTarget.Android;
            buildPlayerOptions.options = BuildOptions.None;

            BuildReport report = BuildPipeline.BuildPlayer(buildPlayerOptions);
            BuildSummary summary = report.summary;

            if (summary.result == BuildResult.Succeeded)
            {
                UnityEngine.Debug.Log("Build succeeded: " + summary.outputPath);
                SaveBuildSetting();
                Autogit();
            }

            if (summary.result == BuildResult.Failed)
            {
                SaveBuildSetting();
                UnityEngine.Debug.Log("Build failed");
            }
        }
    }
    public static void DrawPlayfab()
    {
        GUILayout.Label("Leaderboard");
        EditorGUILayout.Space();
        if (GUILayout.Button("Накинуть"))
        {
            GameObject canvas = GameObject.Find("Canvas");
            if (GameObject.Find("PlayFabManager") == null)
            {
                GameObject PlayFabManager = PrefabUtility.InstantiatePrefab(AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Leaderboard/Prefabs/PlayFabManager.prefab") as GameObject) as GameObject;
                if (EditorUtility.DisplayDialog("Выбор режима настройки",
                                    "Игра производная от ракетки или совершенно иная? Если вы нажмете да, параметры загрузятся сами, если нет, вам необходимо накинуть панель пройгрыша на объект askerads", "Да, накинуть автоматически", "Нет, вручную"))
                {
                    var script = PlayFabManager.GetComponent<PlayFabManager>();
                  //  script.FindSetting();
                }
            }
            if (GameObject.Find("LeaderboardPack") == null)
            {
                GameObject LeaderboardPack = PrefabUtility.InstantiatePrefab(AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Leaderboard/Prefabs/LeaderboardPack.prefab") as GameObject, canvas.transform) as GameObject;
                

            }

        }
        if (GUILayout.Button("Удалить"))
        {
            GameObject PlayFabManager = GameObject.Find("PlayFabManager");
            GameObject LeaderboardPack =GameObject.Find("LeaderboardPack");
            if (PlayFabManager != null)
            {
                DestroyImmediate(PlayFabManager,true);
            }
            if (LeaderboardPack != null)
            {
                DestroyImmediate(LeaderboardPack,true);
            }
        }
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.Space();
    }
    public static void DrawFeedback()
    {
        GUILayout.Label("Feedback asset");
        EditorGUILayout.Space();
        if (GUILayout.Button("Накинуть"))
        {
            GameObject canvas = GameObject.Find("Canvas");
            if (GameObject.Find("FeedbackObject") == null)
            {
                GameObject FeedbackObject = PrefabUtility.InstantiatePrefab(AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Debug_Asset/Feedback/Prefabs/FeedbackObject.prefab") as GameObject, canvas.transform) as GameObject;
                //GameObject FeedbackObject = PrefabUtility.InstantiatePrefab(AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Debug_Asset/Feedback/FeedbackObject.prefab") as GameObject) as GameObject;
                var sss = FeedbackObject.GetComponent<feedbackshow>();
                //sss.Pioskinactive();
                //feedbackshow.instance.Pioskinactive();
            }

            //script.CanvasScreen=GameObject.Find("CanvasScreen");
            //script.CanvasConsole=GameObject.Find("IngameDebugConsole");
        }
        if (GUILayout.Button("Удалить"))
        {
            GameObject FeedbackObject = GameObject.Find("FeedbackObject");
            if (FeedbackObject != null)
            {
                DestroyImmediate(FeedbackObject);
            }
        }
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.Space();
    }
}
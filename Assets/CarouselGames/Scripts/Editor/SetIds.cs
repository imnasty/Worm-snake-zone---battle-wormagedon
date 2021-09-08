using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using System;
using UnityEditor.SceneManagement;

public class SetIds : EditorWindow
    {
        private GameObject[] allWorldsObj;
        private string[] allWorldsNames;
        private int indexOfCurrSelWorld = 0;
        private int ChildCount;

        private string BundleId;
        private string AppleGameName;
        private string AppleGameID;
        private string HuaweiID;

        private string GameName;


        #region UI

        Rect LabelSection;
        Rect OtherSection;

        #endregion

        [MenuItem("Window/Подвязать ID сторов мирам в карусели")]
        static void OpenWindow()
        {

            SetIds window = (SetIds)GetWindow(typeof(SetIds),false ,"ABOBA");
            window.minSize = new Vector2(210, 340);
            window.maxSize = new Vector2(210, 340);
            window.Show();
        }
      

        void FindObjects()
        {   
            GameObject[] allGO = (GameObject[])Resources.FindObjectsOfTypeAll(typeof(GameObject));
            foreach (GameObject go in allGO)
            {
                if (go.gameObject.scene.name != null)
                {
                    if (go.name == "CarouselContent") {
                        ChildCount = go.transform.childCount;
                        allWorldsObj = new GameObject[ChildCount];
                        for (int i = 0; i < ChildCount; i++)
                        {
                            allWorldsObj[i] = go.transform.GetChild(i).gameObject;
                        }
                    }
                }
            }
        }

        void OnEnable()
        {
            FindObjects();
            GetIds();
            allWorldsNames = new string[ChildCount];
            for (int i = 0; i < ChildCount; i++)
            {
                allWorldsNames[i] = allWorldsObj[i].name;
            }

        }

        void OnGUI()
        {
            DrowLayouts();
            DrowInterface();

            
        }

        void DrowLayouts()
        {
            LabelSection.x = 0;
            LabelSection.y = 0;
            LabelSection.width = Screen.width;
            LabelSection.height = 60;

            OtherSection.x = 0;
            OtherSection.y = 60;
            OtherSection.width = Screen.width;
            OtherSection.height = Screen.height - LabelSection.height;
        }

        void DrowInterface()
        {
            GUI.Label(LabelSection, "Выберите мир и впишите ID сторов");

            GUILayout.BeginArea(OtherSection);


            GameName = GUILayout.TextField(allWorldsNames[indexOfCurrSelWorld]);

            GUILayout.BeginHorizontal();

            if (GUILayout.Button("<––", GUILayout.Width(100), GUILayout.Height(20)))
            {
                if (indexOfCurrSelWorld == 0) return;
                indexOfCurrSelWorld--;
                GetIds();

            }
            if (GUILayout.Button("––>", GUILayout.Width(100), GUILayout.Height(20)))
            {
                if (indexOfCurrSelWorld == ChildCount - 1) return;
                indexOfCurrSelWorld++;
                GetIds();
            }
            GUILayout.EndHorizontal();

            GUI.Label(new Rect(0f, LabelSection.y + 40f, Screen.width, 40f), "Bundle ID:");
            GUILayout.Space(30);

            BundleId = GUILayout.TextField(BundleId);
            GUI.Label(new Rect(0f, LabelSection.y + 90f, Screen.width, 20f), "Название игры в App Store:");
            GUILayout.Space(20);
            AppleGameName = GUILayout.TextField(AppleGameName);
            GUI.Label(new Rect(0f, LabelSection.y + 130f, Screen.width, 20f), "ID игры в App Store:");
            GUILayout.Space(20);
            AppleGameID = GUILayout.TextField(AppleGameID);
            GUI.Label(new Rect(0f, LabelSection.y + 170f, Screen.width, 20f), "Huawei ID:");
            GUILayout.Space(20);
            HuaweiID = GUILayout.TextField(HuaweiID);

            GUILayout.Space(20);
            if (GUILayout.Button("Применить", GUILayout.Height(40)))
            {
                GameObject CWo = allWorldsObj[indexOfCurrSelWorld].transform.Find("button").gameObject;
                Selection.activeGameObject = CWo;
                var CW = CWo.GetComponent<CurrentWorld>();
                CW.GetIDs(BundleId, AppleGameName, AppleGameID, HuaweiID, allWorldsNames[indexOfCurrSelWorld]);
            }

            GUILayout.EndArea();

        }

        void GetIds()
        {
            GameObject CWo = allWorldsObj[indexOfCurrSelWorld].transform.Find("button").gameObject;
            var CW = CWo.GetComponent<CurrentWorld>();
            BundleId = CW.BundleID;
            AppleGameName = CW.AppleGameName;
            AppleGameID = CW.AppleGameID;
            HuaweiID = CW.HuaweiGameID;
        }
}

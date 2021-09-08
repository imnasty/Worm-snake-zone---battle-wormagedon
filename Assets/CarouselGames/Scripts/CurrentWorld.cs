using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

    public class CurrentWorld : MonoBehaviour
    {
        #region Google Play
        public string BundleID;
        #endregion

        #region App Store
        public string AppleGameName;
        public string AppleGameID;
        #endregion

        #region Huawei Store
        public string HuaweiGameID;
        #endregion

        private Button thisButton;
        private TextAsset textAsset;
        private string currentStore;

        public void GetIDs(string bundleID, string appleGameName, string appleGameID, string huaweiGameID, string name)
        {
            if (transform.parent.gameObject.name == name)
            {
                BundleID = bundleID;
                AppleGameName = appleGameName;
                AppleGameID = appleGameID;
                HuaweiGameID = huaweiGameID;
            }
        }

        private void Start()
        {
            
            thisButton = gameObject.GetComponent<Button>();
            thisButton.onClick.AddListener(delegate
            {
                GoToStore();
            });
        }

        string GetURL()
        {
            textAsset = Resources.Load("CurrentStore") as TextAsset;
            currentStore = textAsset.text;

            return currentStore switch
            {
                "Google" => "https://play.google.com/store/apps/details?id=" + BundleID,
                "IOS" => "https://apps.apple.com/us/app/" + AppleGameName + "/" + AppleGameID,
                "Huawei" => "https://appgallery.huawei.com/#/app/" + HuaweiGameID,
                _ => "https://play.google.com/store/apps/details?id=" + BundleID,
            };
        }

        void GoToStore()
        {
            Application.OpenURL(GetURL());
        }

    }
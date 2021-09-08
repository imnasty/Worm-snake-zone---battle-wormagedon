using UnityEditor;
using UnityEngine;

namespace WebDAVClient.Editor
{
    public class WebDAVClientEditorFactory
    {
        [MenuItem("Assets/Create/WebDAV Client Object")]
        public static void CreateMyAsset()
        {
            Client asset = ScriptableObject.CreateInstance<Client>();

            AssetDatabase.CreateAsset(asset, "Assets/WebDAVClient.asset");
            AssetDatabase.SaveAssets();

            EditorUtility.FocusProjectWindow();

            Selection.activeObject = asset;
        }
    }
}

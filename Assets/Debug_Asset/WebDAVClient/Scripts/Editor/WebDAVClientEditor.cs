using UnityEditor;
using UnityEngine;

namespace WebDAVClient.Editor
{
    [CustomEditor(typeof(Client))]
    public class WebDAVClientEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            Client webDAVClient = (Client)target;
            if (GUILayout.Button("Reset"))
            {
                webDAVClient.Reset();
            }
        }
    }
}

using UnityEditor;
using UnityEngine;
using WebDAVClient.Helpers;

namespace WebDAVClient.Editor
{
    [CustomPropertyDrawer(typeof(PasswordFieldAttribute))]
    public class PasswordFieldDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            property.stringValue = EditorGUI.PasswordField(position, label, property.stringValue, GUI.skin.textField);
        }
    }
}

using BundlePacker.Core;
using UnityEditor;
using UnityEngine;

namespace BundlePacker.Editor
{
    [CustomPropertyDrawer(typeof(Barcode), true)]
    public class BarcodeDrawer : PropertyDrawer
    {
        public bool draw = true;
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            // Using BeginProperty / EndProperty on the parent property means that
            // prefab override logic works on the entire property.
            EditorGUI.BeginProperty(position, label, property);

            // Draw label
            position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

            // Don't make child fields be indented
            var indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;

            // Calculate rects
            var fieldRect = new Rect(position.x, position.y, 200, position.height);
            var drawRect = new Rect(position.x + fieldRect.width, position.y, 20, position.height);

            // Draw fields - pass GUIContent.none to each so they are drawn without labels
            if (draw)
            {
                EditorGUI.PropertyField(fieldRect, property.FindPropertyRelative("cache"), GUIContent.none);
                if (property.FindPropertyRelative("cache").objectReferenceValue != null) property.FindPropertyRelative("id").stringValue = (property.FindPropertyRelative("cache").objectReferenceValue as Crate).id;
            }
            else EditorGUI.PropertyField(fieldRect, property.FindPropertyRelative("id"), GUIContent.none);

            draw = EditorGUI.Toggle(drawRect, draw);

            // Set indent back to what it was
            EditorGUI.indentLevel = indent;

            EditorGUI.EndProperty();
        }
    }
}
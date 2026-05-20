using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(Barcode<>))]
public class BarcodeDrawer : PropertyDrawer
{
    public bool draw = true;
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        GUILayout.Label(property.displayName);
        GUILayout.BeginHorizontal();
        EditorGUI.BeginProperty(position, label, property);
        if(draw)
            EditorGUILayout.PropertyField(property.FindPropertyRelative("cache"),GUIContent.none);
        else
            EditorGUILayout.PropertyField(property.FindPropertyRelative("id"), GUIContent.none);
        if (property.FindPropertyRelative("cache").objectReferenceValue != null) property.FindPropertyRelative("id").stringValue = (property.FindPropertyRelative("cache").objectReferenceValue as Crate).id;
        EditorGUI.EndProperty();
        draw = GUILayout.Toggle(draw, GUIContent.none);
        GUILayout.EndHorizontal();
    }
}

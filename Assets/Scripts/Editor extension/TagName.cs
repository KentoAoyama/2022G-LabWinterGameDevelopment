using UnityEngine;
using UnityEditor;

public class TagNameAttribute : PropertyAttribute { }

[CustomPropertyDrawer(typeof(TagNameAttribute))]
public class TestTagDropBox : PropertyDrawer
{
	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
	{
		EditorGUI.BeginProperty(position, label, property);
		property.stringValue = EditorGUI.TagField(position, label, property.stringValue);
		EditorGUI.EndProperty();
	}
}
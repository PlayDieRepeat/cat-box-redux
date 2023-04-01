using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(FloatReference))]
public class FloatReferenceDrawer : PropertyDrawer
{
	public override float GetPropertyHeight (SerializedProperty property, GUIContent label)
	{
		int numberOfProperties = 3;
		float padding = EditorGUIUtility.standardVerticalSpacing;
		float propertyHeight = EditorGUIUtility.singleLineHeight;
	
		return (numberOfProperties * propertyHeight) + ((numberOfProperties - 1) * padding) ;
	}

	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
	{
		// Using BeginProperty / EndProperty on the parent means that prefab override logic works on the entire property.
		EditorGUI.BeginProperty(new Rect(position.x, position.y, position.width,position.height), label, property);
		
		// Draw Label
		position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
		
		// No indent on child fields
		var indent = EditorGUI.indentLevel;
		EditorGUI.indentLevel = 0;

		// Calculate rects
		var toggleLabelRect = new Rect(position.x, 
										position.y, 
										position.width/2, 
										EditorGUIUtility.singleLineHeight);
		var toggleRect = new Rect(position.x + position.width/2, 
									position.y , 
									10, 
									EditorGUIUtility.singleLineHeight);
		var inputLabelRect = new Rect(position.x, 
										position.y + EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing, 
									position.width/2, 
										EditorGUIUtility.singleLineHeight);
		var inputRect = new Rect(position.x + position.width/2, 
									position.y + EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing, 
									position.width - position.width/2, 
									EditorGUIUtility.singleLineHeight);

		//get bool property
		var useConstantProp = property.FindPropertyRelative("UseConstant");
		
		// Show the toggle
		EditorGUI.LabelField(toggleLabelRect,new GUIContent("Use Constant?"));
		useConstantProp.boolValue = EditorGUI.Toggle(toggleRect, useConstantProp.boolValue);

		// show appropriate input
		if (useConstantProp.boolValue)
		{
			EditorGUI.LabelField(inputLabelRect,new GUIContent("Float Value"));
			EditorGUI.PropertyField(inputRect, property.FindPropertyRelative("ConstantValue"),GUIContent.none);
		} else
		{
			EditorGUI.LabelField(inputLabelRect,new GUIContent("Float Variable"));
			EditorGUI.PropertyField(inputRect, property.FindPropertyRelative("Variable"),GUIContent.none);
		}
		
		EditorGUI.indentLevel = indent;
		EditorGUI.EndProperty();
	}
}

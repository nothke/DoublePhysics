using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(Vector3d))]
public class Vector3dDrawer : PropertyDrawer
{
    // Draw the property inside the given rect
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        // Using BeginProperty / EndProperty on the parent property means that
        // prefab override logic works on the entire property.
        EditorGUI.BeginProperty(position, label, property);

        // Draw label

        // Don't make child fields be indented
        //var indent = EditorGUI.indentLevel;
        //EditorGUI.indentLevel = 0;

        // Calculate rects

        
        float ldiv = 14;

        EditorGUIUtility.labelWidth = position.width / 4;
        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

        float dv3Width = 40;
        Rect dV3Rect = new Rect(position.x - dv3Width, position.y, dv3Width, position.height);
        EditorGUI.LabelField(dV3Rect, "(dV3)");

        float curX = position.x;
        float sep = position.width / 3;

        var xRect = new Rect(curX, position.y, sep - 2, position.height);
        curX += sep;

        var yL = new Rect(curX, position.y, ldiv, position.height);
        var yRect = new Rect(curX, position.y, sep - 2, position.height);
        curX += sep;

        var zL = new Rect(curX, position.y, ldiv, position.height);
        var zRect = new Rect(curX, position.y, sep - 2, position.height);
        curX += sep;

        // Draw fields - passs GUIContent.none to each so they are drawn without labels
        EditorGUIUtility.labelWidth = ldiv;
        //EditorGUIUtility.fieldWidth = sep - ldiv;
        EditorGUI.PropertyField(xRect, property.FindPropertyRelative("x"), new GUIContent("X"));
        EditorGUI.PropertyField(yRect, property.FindPropertyRelative("y"), new GUIContent("Y"));
        EditorGUI.PropertyField(zRect, property.FindPropertyRelative("z"), new GUIContent("Z"));

        //EditorGUI.DoubleField(xRect, "X", property.FindPropertyRelative("x").doubleValue, );
        //EditorGUI.DoubleField(yRect, "Y", property.FindPropertyRelative("x").doubleValue);
        //EditorGUI.DoubleField(zRect, "Z", property.FindPropertyRelative("x").doubleValue);

        // Set indent back to what it was
        //EditorGUI.indentLevel = indent;

        EditorGUI.EndProperty();
    }
}

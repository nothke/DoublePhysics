using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(Vector3d))]
public class Vector3dDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);

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

        EditorGUIUtility.labelWidth = ldiv;
        EditorGUI.PropertyField(xRect, property.FindPropertyRelative("x"), new GUIContent("X"));
        EditorGUI.PropertyField(yRect, property.FindPropertyRelative("y"), new GUIContent("Y"));
        EditorGUI.PropertyField(zRect, property.FindPropertyRelative("z"), new GUIContent("Z"));

        EditorGUI.EndProperty();
    }
}

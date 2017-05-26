using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;

[CustomEditor(typeof(DRigidbody))]
public class DRigidbodyEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.DrawDefaultInspector();

        DRigidbody drb = (DRigidbody)target;

        GUI.enabled = false;

        EditorGUILayout.LabelField("Position:");
        EditorGUILayout.DoubleField("X: ", drb.position.x);
        EditorGUILayout.DoubleField("Y: ", drb.position.y);
        EditorGUILayout.DoubleField("Z: ", drb.position.z);

        EditorGUILayout.LabelField("Velocity:");
        EditorGUILayout.DoubleField("X: ", drb.velocity.x);
        EditorGUILayout.DoubleField("Y: ", drb.velocity.y);
        EditorGUILayout.DoubleField("Z: ", drb.velocity.z);
    }
}

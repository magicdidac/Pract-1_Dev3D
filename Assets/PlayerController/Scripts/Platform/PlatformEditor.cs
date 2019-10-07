using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

[CustomEditor(typeof(Platform))]
public class PlatformEditor : Editor
{

    public override void OnInspectorGUI()
    {

        Platform p = (Platform)target;

        EditorGUILayout.LabelField("Platform Editor", EditorStyles.boldLabel);
        EditorGUILayout.Space();

        p.speed = EditorGUILayout.FloatField("Move speed", p.speed);
        p.waitTime = EditorGUILayout.FloatField("Stop time (in s)", p.waitTime);

        if (p.isPlayerRequired = EditorGUILayout.Toggle("Is Player Required", p.isPlayerRequired))
            p.backToStart = EditorGUILayout.Toggle("Back to start position", p.backToStart);


        foreach(Vector3 pos in p.nextPos)

        if (GUI.changed)
            EditorUtility.SetDirty(p);

    }

}

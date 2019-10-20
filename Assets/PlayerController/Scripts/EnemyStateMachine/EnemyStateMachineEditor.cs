using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(EnemyStateMachine))]
public class EnemyStateMachineEditor : Editor
{

    private void OnSceneGUI()
    {
        EnemyStateMachine esm = (EnemyStateMachine)target;

        if (esm.currentState != null)
            Handles.Label(esm.transform.position + Vector3.up, "State: " + esm.currentState.ToString(), EditorStyles.boldLabel);
        else
            Handles.Label(esm.transform.position + Vector3.up, "State: Null", EditorStyles.boldLabel);

    }

}

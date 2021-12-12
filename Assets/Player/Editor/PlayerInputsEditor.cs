using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(PlayerInputs))]
public class PlayerInputsEditor : Editor
{
    private PlayerInputs playerInputs;
    private void OnEnable()
    {
        playerInputs = (PlayerInputs)target;
    }
    //inspector内の値がなにかしら変化ないと値の表示は更新されない
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        using (new GUILayout.HorizontalScope())
        {
            EditorGUILayout.LabelField("arrow");
            using (new GUILayout.VerticalScope())
            {
                EditorGUILayout.LabelField(playerInputs.up ? "　↑":"");
                EditorGUILayout.LabelField(
                    (playerInputs.left ? "←" : "　") +
                    (playerInputs.down ? "↓" : "　") +
                    (playerInputs.right ? "→" : "　")
                    );
            }
        }
        EditorGUILayout.Toggle("fire", playerInputs.fire);
        using (new GUILayout.HorizontalScope())
        {
            EditorGUILayout.Toggle("accel", playerInputs.accel);
            EditorGUILayout.Toggle("decel", playerInputs.decel);
        }


    }
}

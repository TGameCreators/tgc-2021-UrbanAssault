using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
//参考 拡張エディタでTooltipを表示する
//https://zenn.dev/kumas/books/325ed71592f6f5/viewer/6e20d4

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
            EditorGUILayout.LabelField(new GUIContent("arrow", "上下左右の入力が表示される"));
            using (new GUILayout.VerticalScope())
            {

                EditorGUILayout.LabelField(playerInputs.arrow.y > 0 ? "　↑" : "");
                EditorGUILayout.LabelField(
                       (playerInputs.arrow.x < 0 ? "←" : "　")
                     + (playerInputs.arrow.y < 0 ? "↓" : "　")
                     + (playerInputs.arrow.x > 0 ? "→" : "　"));

            }
        }
        EditorGUILayout.Toggle(new GUIContent("fire", "攻撃ボタン"), playerInputs.fire);
        using (new GUILayout.HorizontalScope())
        {
            EditorGUILayout.Toggle(new GUIContent("accel", "加速入力"), playerInputs.accel);
            EditorGUILayout.Toggle(new GUIContent("decel", "減速入力"), playerInputs.decel);
        }
        using (new GUILayout.HorizontalScope())
        {
            EditorGUILayout.Toggle(new GUIContent("map", "マップ表示"), playerInputs.map);
            EditorGUILayout.Toggle(new GUIContent("squad", "部隊編成表示"), playerInputs.squad);
        }

    }
}

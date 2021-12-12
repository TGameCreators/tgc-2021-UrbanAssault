using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleAnimation : MonoBehaviour
{
    public float interval; // セグメントの時間間隔
    public GameObject[] waypoints; // 経由するオブジェクト
    private float startTime;
    void Start()
    {
        startTime = Time.time;
    }
    void Update()
    {
        float s = (Time.time - startTime) / interval;
        int seg = (int)s % (waypoints.Length - 1); // 補間セグメントを求める
        float a = s - Mathf.Floor(s); // セグメント内での進行率
        Vector3 pos1 = waypoints[seg].transform.position;
        Vector3 pos2 = waypoints[seg + 1].transform.position;
        transform.position = Vector3.Lerp(pos1, pos2, a); // 進行率で線形補間
    }
}

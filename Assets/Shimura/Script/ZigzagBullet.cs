using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using DG.Tweening;

public class ZigzagBullet : Bullet
{
    //必要になったらDOTweenインポートしてください
    /*
    [SerializeField]
    GameObject BulletBody;

    [SerializeField,Tooltip("往復時間"),Range(0,1.0f)]
    float RoundTripTime;

    [SerializeField, Tooltip("ジグザグ度合い"), Range(0, 10)]
    public float Zigzag;
    
    protected override void Start()
    {
        base.Start();
        BulletBody = transform.GetChild(0).gameObject;
        StartCoroutine("ZigzagMove");
    }

    protected override void Update()
    {
        base.Update();
    }

    IEnumerator ZigzagMove()
    {
        BulletBody.transform.DOLocalMove(new Vector3(Zigzag/2, 0, 0), RoundTripTime/2);
        yield return new WaitForSeconds(RoundTripTime/2);
        while (true)
        {
            BulletBody.transform.DOLocalMove(new Vector3(-Zigzag, 0, 0), RoundTripTime / 2);
            yield return new WaitForSeconds(RoundTripTime / 2);
            BulletBody.transform.DOLocalMove(new Vector3(Zigzag / 2, 0, 0), RoundTripTime / 2);
            yield return new WaitForSeconds(RoundTripTime / 2);
        }
    }
    */
}

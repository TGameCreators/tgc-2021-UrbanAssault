/*
 * 弾の飛び方は継承したクラスが決める 
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    [Tooltip("弾の種類")]
    protected Rigidbody BulletRig;
    float Timer;
    [SerializeField,Tooltip("弾の消滅時間")] 
    float DeleteTime;
    [Tooltip("弾の攻撃力（Gunスクリプトから取得）")] 
    float Attack;//Gunスクリプト→Bulletスクリプトで取得）
    [SerializeField,Tooltip("追尾性能")]
    float TrackingPerformance;




    protected virtual void Start()
    {
        Timer = 0;
        transform.parent = null;
        BulletRig = GetComponent<Rigidbody>();
        Debug.Log("弾攻撃力："+Attack);
    }

    
    protected virtual void Update()
    {
        Timer += Time.deltaTime;
        if (Timer >= DeleteTime) Destroy(this.gameObject);

        //追尾機能
        if (LookOn.TargetPos != null)
        {
            Vector3 DirectionCorrection = Vector3.MoveTowards(transform.position, LookOn.TargetPos.transform.position, TrackingPerformance * Timer);
            //BulletRig.AddForce(DirectionCorrection,ForceMode.Impulse);
            transform.position = DirectionCorrection;
        }
    }


    protected virtual void OnTriggerEnter(Collider other)
    {
        //当たり判定の処理
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("命中");
            Destroy(gameObject);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        //当たり判定の処理
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("命中");
            Destroy(gameObject);
        }
    }

    public void SetAttack(float Attack)
    {
        this.Attack = Attack;
    }
}

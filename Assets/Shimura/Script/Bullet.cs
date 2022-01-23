/*
 * 弾の飛び方は継承したクラスが決める 
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    protected Rigidbody BulletRig;
    float Timer;
    public float DeleteTime;//弾が生成されてから消えるまでの時間
    public int Speed = 1000;
    [SerializeField] float Attack;//弾の攻撃力（Fighterスクリプト→Weaponスクリプト→Bulletスクリプトで取得）




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
    }


    protected virtual void OnTriggerEnter(Collider other)
    {
        //当たり判定の処理    
    }

    public void SetAttack(float Attack)
    {
        this.Attack = Attack;
    }
}

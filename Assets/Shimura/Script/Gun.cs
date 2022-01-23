using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    GameObject GunWeapon;
    Fighter Fighter;//この銃を搭載している親オブジェクト
    public GameObject Bullet;//銃にセットした弾
    GameObject FireBullet;//発射した弾
    Rigidbody BulletRig;
    Transform MuzzlePos;
    public float BulletSpeed;
    float Attack;//弾の攻撃力（親オブジェクトから取得）


    void Start()
    {
        GunWeapon = this.gameObject;
        MuzzlePos = transform.Find("Muzzle").GetComponent<Transform>();
        Fighter = transform.parent.gameObject.GetComponent<Fighter>();
        Attack = Fighter.GetAttack();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) Shoot();
        Bullet = BulletManager.UsingBullet;
    }


    //弾の生成と銃の正面方向に力を加える
    void Shoot()
    {
        //弾生成
        FireBullet=Instantiate(Bullet, MuzzlePos.transform);
        //弾の攻撃力を設定
        Bullet b = FireBullet.GetComponent<Bullet>();
        b.SetAttack(Attack);
        //弾を前方に飛ばす
        BulletRig = FireBullet.GetComponent<Rigidbody>();
        BulletRig.AddForce(GunWeapon.transform.forward * BulletSpeed);  
        
    }

}

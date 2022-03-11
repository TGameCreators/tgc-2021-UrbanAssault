using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    GameObject GunWeapon;
    public GameObject Bullet;//銃にセットした弾
    GameObject FireBullet;//発射した弾
    Rigidbody BulletRig;
    Transform MuzzlePos;
    [Tooltip("弾のスピード")]
    public float BulletSpeed;
    [Tooltip("弾の攻撃力")]
    public float Attack;//弾の攻撃力
    [SerializeField, Tooltip("連射性能（何秒おきに弾を撃つか）")]
    float DelayTimeofFiring;//銃の連射速度
    float Timer;
    bool ShootRock;//Trueの場合はShoot関数で射撃できる



    void Start()
    {
        Timer = 0;
        GunWeapon = this.gameObject;
        MuzzlePos = transform.Find("Muzzle").GetComponent<Transform>();
        ShootRock = true;
    }

    // Update is called once per frame
    void Update()
    {
        //弾を発射して次に撃てるまでの時間を測る
        if (!ShootRock)
        {
            Timer += Time.deltaTime;
            if (Timer > DelayTimeofFiring)
            {
                ShootRock = true;
                Timer = 0;
            }
        }
    }


    //弾の生成と銃の正面方向に力を加える
    public void Shoot()
    {
        if (ShootRock)
        {
            //弾生成
            FireBullet = Instantiate(Bullet, MuzzlePos.transform);
            //弾の攻撃力を設定
            Bullet b = FireBullet.GetComponent<Bullet>();
            b.SetAttack(Attack);
            //弾を前方に飛ばす
            BulletRig = FireBullet.GetComponent<Rigidbody>();
            BulletRig.AddForce(GunWeapon.transform.forward * BulletSpeed);
            ShootRock = false;
        }
    }
}

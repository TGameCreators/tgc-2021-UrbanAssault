using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Base_Tank : Macine
{
    // Start is called before the first frame update
    Rigidbody Rb;
    Vector3 Time1;
    public GameObject Bullet;
    public int BulletSpeed=100;
    float DelayTimeofFiring;
    private GameObject ThisTank;
    [SerializeField]public GameObject Gun;//銃
    Vector3 vec;//銃の位置
    void Start()
    {
        Rb = this.gameObject.GetComponent<Rigidbody>();
        Vector3 Time1 = this.gameObject.transform.position;
        DelayTimeofFiring = GetDelayTimeofFiring();
        ThisTank = this.gameObject;
        Gun = transform.Find("GUN/Gun").gameObject;
        
    }

    public void ConstructorBase_Tank(int num, float Attack, float Acceleration, float Decelerate, float DelayTimeofFiring, float RotateSpeed, int BulletNumofFiring, Vector3 MaxSpeed) 
    {
        ConstructorMacine(num, Attack, Acceleration, Decelerate, DelayTimeofFiring, RotateSpeed, BulletNumofFiring, MaxSpeed);
    }

    // Update is called once per frame
    [SerializeField]float Timer;
    void Update()
    {
        Accelerate(Rb);
        Rotate();
        Measurement(Rb);
        Timer += Time.deltaTime;
        if (Input.GetKey(KeyCode.W))
        {
            if (Timer > DelayTimeofFiring)
            {
                Fire();
                Timer = 0;
            }
        }


    }
    public void Accelerate(Rigidbody Rb)//前進への加速
    {
        if (SpeedComparison())
        {
            Debug.Log("Moob");
            Rb.AddForce(transform.forward * GetAcceleration() * Input.GetAxis("Horizontal"));


        }

    }
    public void Rotate()//回転
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {

            this.gameObject.transform.Rotate(new Vector3(0, -GetRotateSpeed(), 0));
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {

            this.gameObject.transform.Rotate(new Vector3(0, GetRotateSpeed(), 0));

        }
    }
    
    public void Measurement(Rigidbody Rb)//現在のスピードを算出する
    {
        SetSpeed(Rb.velocity);
    }

    public void Fire()
    {
        vec = Gun.transform.position;
        GameObject bullet=Instantiate(Bullet, vec, Quaternion.identity);
        bullet.GetComponent<Bullet_Tank>().Fire(ThisTank);
        
    }
}

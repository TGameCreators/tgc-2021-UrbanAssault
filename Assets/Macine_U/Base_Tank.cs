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
    [SerializeField]public GameObject Muzzle;//?e??
    [SerializeField] public GameObject Gun;//?e
    Vector3 vec;//?e?̈ʒu
    void Start()
    {
        Rb = this.gameObject.GetComponent<Rigidbody>();
        Vector3 Time1 = this.gameObject.transform.position;
        DelayTimeofFiring = GetDelayTimeofFiring();
        ThisTank = this.gameObject;

        //?e???̒T??
        Muzzle = transform.Find("GUN/Gun").gameObject;

        //?e?̒T??
        Gun= transform.Find("GUN").gameObject;
        Gun.transform.Rotate(new Vector3(-GetRotateSpeed()*2, 0, 0));

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
        MoobGun();


    }
    public void Accelerate(Rigidbody Rb)//?O?i?ւ̉???
    {
        if (SpeedComparison())
        {
            //Debug.Log("Moob");
            Rb.AddForce(transform.forward * GetAcceleration() * Input.GetAxis("Horizontal"));
            Rb.AddForce(transform.forward * GetAcceleration() * Input.GetAxis("Vertical") *(-1));


        }

    }
    public void Rotate()//???]
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
    
    public void Measurement(Rigidbody Rb)//???݂̃X?s?[?h???Z?o????
    {
        SetSpeed(Rb.velocity.sqrMagnitude);
    }
    /// <summary>
    /// ?e?̔???
    /// </summary>
    public void Fire()
    {
        vec = Muzzle.transform.position;
        GameObject bullet=Instantiate(Bullet, vec,this.transform.rotation);
        bullet.GetComponent<Bullet_Tank>().Fire(Muzzle);
        
    }
    private float MaxRotate=1.00f;
    private float MinRotate=0.95f;
    public float x;
    /// <summary>
    /// ???Ԃ̏??ɂ????e???㉺?ɓ?????
    /// </summary>
    /// <param name="n"></param>
    public void MoobGun()
    {
        x = Gun.transform.rotation.x;
       
        if(x <= MaxRotate)
        {
            if(x >= MinRotate)
            {
                if (Input.GetKey(KeyCode.Q))
                {
                    Gun.transform.Rotate(new Vector3(-GetRotateSpeed(), 0, 0));
                    if(Gun.transform.rotation.x <= MinRotate)
                    {
                        Gun.transform.Rotate(new Vector3(GetRotateSpeed(), 0, 0));
                    }

                }
                else if (Input.GetKey(KeyCode.E))
                {
                    Gun.transform.Rotate(new Vector3(GetRotateSpeed(), 0, 0));
                    if (Gun.transform.rotation.x >= MaxRotate)
                    {
                        Gun.transform.Rotate(new Vector3(-GetRotateSpeed(), 0, 0));
                    }

                }
            }
        }

    }
    
}

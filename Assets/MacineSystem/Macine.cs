using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Macine : ImgMacine
{
    protected float Attack;//privateからprotectedに変更した　志村
    protected float Acceleration;//privateからprotectedに変更した　志村
    float Decelerate;
    float DelayTimeofFiring;
    float RotateSpeed;
    int BulletNumofFiring;
    protected Vector3 MaxSpeed;//privateからprotectedに変更した 志村
    Vector3 Speed;
    protected Rigidbody Rb;

    public virtual void Start()
    {
        Rb = this.gameObject.GetComponent<Rigidbody>();
    }
    void Update()
    {
        Accelerate(Rb);
    }

    public Macine(int num,float Attack,float Acceleration):base(num)
    {
        this.Attack = Attack;
        this.Acceleration = Acceleration;
    }

    public void Accelerate(Rigidbody Rb)
    {
        
        if (Input.GetKey(KeyCode.W))
        {
            if (SpeedComparison('W'))
            {
                Rb.AddForce(transform.forward * Acceleration);
            }
        }
        
    }

    public bool SpeedComparison(char axes)
    {
        switch (axes)
        {
            
            case 'W':
                if(Speed.x > MaxSpeed.x)
                {
                    return true;
                }
                break;
            
        }
        return false;
    }
    public virtual void Rotate()
    {

    }

    public void Firing()
    {

    }

    public void Break()
    {
        
    }

    public void DecelerateSpeed()
    {

    }


}

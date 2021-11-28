using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Macine : ImgMacine
{
    float Attack;
    float Acceleration;
    float Decelerate;
    float DelayTimeofFiring;
    float RotateSpeed;
    int BulletNumofFiring;
    Vector3 MaxSpeed;
    Vector3 Speed;
    void Start()
    {
        Rigidbody Rb = this.gameObject.GetComponent<Rigidbody>();
    }

    public Macine(int num):base(num)
    {

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

    public void Firing()
    {

    }

    public void Break()
    {

    }

    public void DecelerateSpeed()
    {

    }

    public void Rotate()
    {

    }
}

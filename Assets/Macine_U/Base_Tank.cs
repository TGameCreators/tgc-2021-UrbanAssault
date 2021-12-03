using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base_Tank : Macine
{
    // Start is called before the first frame update
    Rigidbody Rb;
    void Start()
    {
        Rb = this.gameObject.GetComponent<Rigidbody>();
    }
    public void ConstructorBase_Tank(int num, float Attack, float Acceleration, float Decelerate, float DelayTimeofFiring, float RotateSpeed, int BulletNumofFiring, Vector3 MaxSpeed) 
    {
        ConstructorMacine(num, Attack, Acceleration, Decelerate, DelayTimeofFiring, RotateSpeed, BulletNumofFiring, MaxSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        base.Accelerate(Rb);
    }
}

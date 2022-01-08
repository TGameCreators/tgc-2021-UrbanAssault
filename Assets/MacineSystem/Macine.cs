using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class Macine : ImgMacine
{
    [SerializeField] private float Attack;
    [SerializeField] private float Acceleration;
    [SerializeField] private float Decelerate;
    [SerializeField] private float DelayTimeofFiring;
    [SerializeField] private float RotateSpeed;
    [SerializeField] private int BulletNumofFiring;
    [SerializeField] private Vector3 MaxSpeed;
    [SerializeField] private float Speed;
    



    public void ConstructorMacine(int num, float Attack, float Acceleration, float Decelerate, float DelayTimeofFiring, float RotateSpeed, int BulletNumofFiring, Vector3 MaxSpeed) 
    {
        ConstructorImgMacine(num);
        this.Attack = Attack;
        this.Acceleration = Acceleration;
        this.Decelerate = Decelerate;
        this.DelayTimeofFiring = DelayTimeofFiring;
        this.RotateSpeed = RotateSpeed;
        this.BulletNumofFiring = BulletNumofFiring;
        this.MaxSpeed = MaxSpeed;
    }

    

    public float GetAttack()//Attackのgetter
    {
        return Attack;
    }

    public bool SpeedComparison()//現在のスピードとMaxスピードを比較
    {
        //Debug.Log("Comparison");

        if (MaxSpeed.sqrMagnitude > Speed)
        {
            return true;
        }
        Debug.Log("速度制限");
        return false;
    }
    
    

    public void Firing()//発射
    {

    }

    public void Break()//壊れる
    {

    }

    public void DecelerateSpeed()//減速
    {

    }
    public float GetAcceleration()
    {
        return Acceleration;
    }
    public float GetRotateSpeed()
    {
        return RotateSpeed;
    }
    public float GetDelayTimeofFiring()
    {
        return DelayTimeofFiring;
    }
    public void SetSpeed(float speed)
    {
        Speed = speed;
    }



}

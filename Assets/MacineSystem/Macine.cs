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
    [SerializeField] private Vector3 Speed;
    



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
        Debug.Log("Comparison");

        if (Speed.x < MaxSpeed.x)
        {
            Debug.Log("ComparisonX");
            if (Speed.y<MaxSpeed.y)
            {
                Debug.Log("ComparisonY");
                if (Speed.z<MaxSpeed.z)
                {
                    Debug.Log("ComparisonY");
                    return true;
                }
            }
            
        }
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
    public void SetSpeed(Vector3 vec)
    {
        Speed.x = Mathf.Abs(vec.x);
        Speed.y = Mathf.Abs(vec.y);
        Speed.z = Mathf.Abs(vec.z);
    }



}

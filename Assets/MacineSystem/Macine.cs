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

    public void Accelerate(Rigidbody Rb)//前進への加速
    {

        
            
            if (SpeedComparison())
            {
                Debug.Log("Moob");
                Rb.AddForce(transform.forward * Acceleration* Input.GetAxis("Horizontal"));


            }
        
        
        

    }

    public bool SpeedComparison()//現在のスピードとMaxスピードを比較
    {
        Debug.Log("Comparison");
        Measurement();


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
    public async void Measurement()//現在のスピードを算出する
    {
        Vector3 Time = this.gameObject.transform.position;
        await Task.Delay(1000);
        Vector3 Time2 = this.gameObject.transform.position;
        Speed.x =Mathf.Abs(Mathf.Sqrt(Time.x * Time.x) - Mathf.Sqrt(Time2.x * Time.x));
        Speed.y = Mathf.Abs(Mathf.Sqrt(Time.y * Time.y) - Mathf.Sqrt(Time2.y * Time.y));
        Speed.z = Mathf.Abs(Mathf.Sqrt(Time.z * Time.z) - Mathf.Sqrt(Time2.z * Time.z));
    }
    public void Rotate()//回転
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {

            this.gameObject.transform.Rotate(new Vector3(0, -RotateSpeed, 0));
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {

            this.gameObject.transform.Rotate(new Vector3(0, RotateSpeed, 0));

        }
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


}

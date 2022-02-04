using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class Macine : ImgMacine
{
    [SerializeField] protected float Attack;
    [SerializeField] protected float acceleration;
    [SerializeField] protected float DelayTimeofFiring;
    [SerializeField] protected float rotate_speed;
    [SerializeField] protected int BulletNumofFiring;
    [SerializeField] protected Vector3 maxSpeed;
    protected Rigidbody rb;
    protected Transform tf;
    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody>();
        tf = GetComponent<Transform>();
    }
    public bool SpeedComparison()//現在のスピードとMaxスピードを比較
    {
        //Debug.Log("Comparison");
        
        if (maxSpeed.sqrMagnitude > rb.velocity.sqrMagnitude)
        {
            return true;
        }
        Debug.Log("速度制限");
        return false;
    }
    
    public virtual void Arrow(Vector3 oder)
    {
        if (!SpeedComparison())
        {
            return;
        }
    }

    public virtual void PushA()
    {

    }
    public virtual void PushZ()
    {

    }

    public void Firing()//発射
    {

    }

    public void Break()//壊れる
    {

    }




}

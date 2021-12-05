using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : Macine
{
    [SerializeField] float wingsArea;     //���̖ʐ�
    [SerializeField] float airDensity;    //��C���x
    [SerializeField] float speed;         //���x
    [SerializeField] float cl;            //�g�͌W��


    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        MaxSpeed = new Vector3(10,10,10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Accelerate();
    }

    public Fighter(int num, float Attack, float Acceleration) : base(num,Attack,Acceleration)
    {
        this.Attack = Attack;
        this.Acceleration = Acceleration;
    }

    void Accelerate()
    {
        var forces = Vector3.zero;
        forces = speed * transform.forward;
        Debug.Log("transform.forward"+ transform.forward);
        Debug.Log("forces" + forces);
        //�g�͂̕���
        Vector3 liftDirection = Vector3.Cross(Rb.velocity, transform.forward).normalized;
        var liftPower = lift(airDensity, wingsArea, speed, cl) / 1000 * Time.deltaTime;
        forces += liftPower * liftDirection;
        //MaxSpeed�������x����������Ή����i�������ێ��������j
        if(Rb.velocity.magnitude<10)Rb.AddForce(forces);
    }

    //�g�͂��擾
    float lift(float air, float wing, float spd, float cl)
    {
        //�g��  =��C���x*���̖ʐ�*���x�̓��*�g�͌W��/ 2
        float l =   air  *   wing *  spd*spd *   cl   / 2;
        return l;
    }

    //�Q�l�@https://teratail.com/questions/331607

    public override void Rotate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            //�@�̂��X���ĉE�֋Ȃ���
        }
        if (Input.GetKey(KeyCode.A))
        {
            //�@�̂��X���č��֋Ȃ���
        }
    }
}
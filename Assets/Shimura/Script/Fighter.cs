using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : Macine
{
    [SerializeField] float wingsArea;     //翼の面積
    [SerializeField] float airDensity;    //空気密度
    [SerializeField] float speed;         //速度
    [SerializeField] float cl;            //揚力係数

    [SerializeField] protected Rigidbody Rb;

    float XZRotate;//戦闘機を左右に旋回させる
    float XYRotate;//戦闘機を上下に向ける


    // Start is called before the first frame update
    public void Start()
    {
        Rb = this.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        Accelerate();//正面に進む
    }

    public Fighter(int num, float Attack, float Acceleration)
    {

    }

    void Accelerate()
    {
        var forces = Vector3.zero;
        forces = speed * transform.forward;
        //揚力の方向
        Vector3 liftDirection = Vector3.Cross(Rb.velocity, transform.forward).normalized;
        var liftPower = lift(airDensity, wingsArea, speed, cl) / 1000 * Time.deltaTime;
        forces += liftPower * liftDirection;
        //MaxSpeedよりも速度が小さければ加速（等速を維持したい）
        if (Rb.velocity.magnitude < 10) Rb.AddForce(forces);
    }

    //揚力を取得
    float lift(float air, float wing, float spd, float cl)
    {
        //揚力  =空気密度*翼の面積*速度の二乗*揚力係数/ 2
        float l = air * wing * spd * spd * cl / 2;
        return l;
    }

    //参考　https://teratail.com/questions/331607


    public void Rise()
    {
        if (XYRotate > -30) XYRotate -= 0.5f;//機首を上げる
        transform.rotation = Quaternion.Euler(XYRotate, XZRotate, 0);
    }

    public void Descent()
    {
        if (XYRotate < 30) XYRotate += 0.5f;//機首を下げる
        transform.rotation = Quaternion.Euler(XYRotate, XZRotate, 0);
    }

    public void TurnRight()
    {
        XZRotate += 0.5f;//右旋回
        transform.rotation = Quaternion.Euler(XYRotate, XZRotate, 0);
    }

    public void TurnLeft()
    {
        XZRotate -= 0.5f;//左旋回
        transform.rotation = Quaternion.Euler(XYRotate, XZRotate, 0);
    }
}

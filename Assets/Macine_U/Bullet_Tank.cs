using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Tank : Bullet
{
    GameObject ParentTank;
    Rigidbody Rb;
    public void Fire(GameObject Tank)
    {
        ParentTank = Tank;
        Rb = this.gameObject.GetComponent<Rigidbody>();
    }
    protected override void Update()
    {
        base.Update();
        Rb.AddForce(ParentTank.transform.forward * 1);
    }


}

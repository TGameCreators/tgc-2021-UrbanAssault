using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank_Aim_Function : Tank_Move_Function
{
    private Transform transform_gun;
    protected override void Start()
    {
        base.Start();
        transform_gun = transform.Find("GUN").transform;
    }

    protected override void Update()
    {
        base.Update();
        if (Input.GetKey(KeyCode.A))
        {
            PushA();
        }
        else if (Input.GetKey(KeyCode.Z))
        {
            PushZ();
        }
        checkrotate = transform_gun.rotation.z;
    }
    [SerializeField] private float max_rotate = 0.6f;
    [SerializeField] private float min_rotate = 0.5f;
    public float checkrotate;
    public override void PushA()
    {
        
        if (transform_gun.rotation.z > min_rotate)
        {
            transform_gun.Rotate(new Vector3(0, 0, rotate_speed));
            
            
        }
    }
    public override void PushZ()
    {
        
        if (transform_gun.rotation.z < max_rotate)
        {
            transform_gun.Rotate(new Vector3(0, 0, rotate_speed));
            
        }
        
    }
}

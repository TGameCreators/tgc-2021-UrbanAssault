using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank_Move_Function : Macine
{
    // Start is called before the first frame update
    private Vector3 zero;
    public bool player_existence;//仮置きのプレイヤー存在変数
    protected override void Start()
    {
        base.Start();
        zero = new Vector3(0, 0, 0);
        player_existence = true;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (player_existence)
        {
            Arrow(zero);
        }
        
    }
    public override void Arrow(Vector3 oder)
    {
        base.Arrow(oder);//速度制限の確認
        if (Input.GetKey(KeyCode.UpArrow))
        {
            oder.x = 1;
        }else if (Input.GetKey(KeyCode.DownArrow))
        {
            oder.x = -1;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            oder.y = 1;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            oder.y = -1;
        }
        rb.AddForce(tf.forward * acceleration *oder.x);
        tf.Rotate(new Vector3(0, rotate_speed*oder.y, 0));
    }
}

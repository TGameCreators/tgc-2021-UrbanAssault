/*
 * ’e‚Ì”ò‚Ñ•û‚ÍŒp³‚µ‚½ƒNƒ‰ƒX‚ªŒˆ‚ß‚é 
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    protected GameObject Weapon;//e
    protected Rigidbody BulletRig;
    private float Timer;
    public float DeleteTime;//’e‚ª¶¬‚³‚ê‚Ä‚©‚çÁ‚¦‚é‚Ü‚Å‚ÌŠÔ
    public int Speed = 1000;



    
    protected virtual void Start()
    {
        Timer = 0;
        Weapon = transform.parent.gameObject;
        Debug.Log("Weapon="+Weapon);
        transform.parent = null;
        BulletRig = GetComponent<Rigidbody>();
    }

    
    protected virtual void Update()
    {
        Timer += Time.deltaTime;
        if (Timer >= DeleteTime) Destroy(this.gameObject);
    }


    protected virtual void OnTriggerEnter(Collider other)
    {
        //“–‚½‚è”»’è‚Ìˆ—    
    }
}

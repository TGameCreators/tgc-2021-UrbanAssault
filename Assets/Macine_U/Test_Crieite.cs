using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Crieite : MonoBehaviour
{
    // Start is called before the first frame update
    Base_Tank TankM;
    public GameObject obj;
    public GameObject bullet;
    GameObject TankS;
    void Start()
    {
        TankS=Instantiate(obj, new Vector3(0.0f, 2.0f, 0.0f), Quaternion.identity);
        TankS.AddComponent<Base_Tank>();
        TankS.GetComponent<Base_Tank>().ConstructorBase_Tank(0000, 10, 10, 1, 1, 0.04f, 2, new Vector3(500, 500, 500));
        TankS.GetComponent<Base_Tank>().Bullet = bullet;
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

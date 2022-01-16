using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Crieite : MonoBehaviour
{
    // Start is called before the first frame update
    Base_Tank TankM;
    public GameObject obj;
    public GameObject bullet;
    public GameObject Gun;
    GameObject TankS;
    void Start()
    {

        TankS=Instantiate(obj, new Vector3(0.0f, 2.0f, 0.0f), Quaternion.identity);
        TankS.AddComponent<Base_Tank>();

        TankS.GetComponent<Base_Tank>().ConstructorBase_Tank(0000, 10, 10, 10, 2, new Vector3(500, 10, 500));
        



    }

}

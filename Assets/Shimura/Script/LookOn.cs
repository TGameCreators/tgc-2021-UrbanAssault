using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LookOn : MonoBehaviour
{
    [SerializeField, Tooltip("メインのカメラをセット\nRayの開始地点")]
    Camera camera;//Rayの開始地点（カメラは戦闘機を追従している）
    [SerializeField, Tooltip("playerを設定")]
    GameObject Player;
    [SerializeField, Tooltip("CanvasのRectTransform")]
    RectTransform CanvasRect;
    [SerializeField, Tooltip("照準のRectTransform")]
    RectTransform RT;
    [SerializeField,Tooltip("標準時の画像:[0]\nロックオン時の画像:[1]")]
    Sprite[] Sprite;
    Image UsingImage;
    [SerializeField,Tooltip("ちゃんと格納されているか確認用" +
        "\nRayが当たっているオブジェクトが格納されていればOK" +
        "\nRayが当たっていないときはnullになる")]
    GameObject TargetPos;
    float Distance;//プレイヤーと敵（ターゲット中）との距離
    Vector3 TargetPoint;//照準の位置
    RaycastHit hit;

    void Start()
    {
        RT = this.GetComponent<RectTransform>();
        UsingImage = this.GetComponent<Image>();
        UsingImage.sprite = Sprite[0];
    }

    void Update()
    {
        if (TargetPos != null)
        {
            Distance = Vector3.Distance( TargetPos.transform.position,Player.transform.position);
            //TargetPoint = Camera.main.WorldToScreenPoint(TargetPos.transform.position);
            //RT.position = TargetPoint;
            Vector2 pos;
            Vector2 ScreenPos=RectTransformUtility.WorldToScreenPoint(camera, TargetPos.transform.position);
            RectTransformUtility.ScreenPointToLocalPointInRectangle(CanvasRect, ScreenPos, camera, out pos);
            RT.position = pos;
        }
    }

    private void FixedUpdate()
    {
        //Debug.DrawRay(Player.transform.position, Vector3.forward, Color.blue);
        if (Physics.BoxCast(Player.transform.position, new Vector3(40f, 20f, 1f),
            Vector3.forward, out hit, Quaternion.identity, 100f, LayerMask.GetMask("Enemy")))
        {
            //Rayがヒットしたときの処理
            if (hit.collider.CompareTag("Enemy"))
            {
                LockonStart();
            }
            else
            {
                LockonEnd();
            }
        }
        else
        {
            LockonEnd();
        }
    }

        //Rayで敵を補足したら呼び出す
        public void LockonStart()
    {
        Debug.Log("hit");
        TargetPos = hit.collider.gameObject;
        Debug.Log("Target:"+TargetPos);
        UsingImage.sprite = Sprite[1];
    }

    //Rayで敵を見失ったら呼び出す
    public void LockonEnd()
    {
        Debug.Log("no hit");
        TargetPos = null;
        RT.localPosition=new Vector3(0f,0f,0f);
        UsingImage.sprite = Sprite[0];
    }

    void OnDrawGizmos()
    {
        //　Cubeのレイを疑似的に視覚化
        Gizmos.color = Color.green;
        //Gizmos.DrawWireCube(Player.transform.position + transform.forward * Distance, new Vector3(40f, 20f, 1f));
        Gizmos.DrawWireCube(hit.point, new Vector3(40f, 20f, 1f));
    }





    /*
    [SerializeField,Tooltip("メインのカメラをセット\nRayの開始地点")]
    Camera camera;//Rayの開始地点（カメラは戦闘機を追従している）
    [SerializeField, Tooltip("ロックオン時にターゲットUIを変更")]
    Sprite[] Sprite;
    Image Image;
    [SerializeField, Tooltip("照準のUIを設定")]
    GameObject AimUI;
    [SerializeField, Tooltip("playerを設定")]
    GameObject Player;

    void Start()
    {
        Image =AimUI.GetComponent<Image>();
        Debug.Log(Sprite);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        
        RaycastHit hit;
        Debug.DrawRay(Player.transform.position, Vector3.forward, Color.blue);
        if(Physics.Raycast(Player.transform.position, Vector3.forward,out hit))
        {
            //Rayがヒットしたときの処理
            if (hit.collider.CompareTag("Enemy"))
            {
                Image.sprite = Sprite[1];//UIの色を変える
                Debug.Log("hit");
                //UIをEnemyの位置に持っていく
            }
            else
            {
                Image.sprite = Sprite[0];//標準の色
                Debug.Log("no hit");
            }
            
        }
    }
    */

}

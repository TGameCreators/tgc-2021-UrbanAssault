using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputs : MonoBehaviour
{
    [SerializeField,Tooltip("キー設定")]
    private InputKeyConfig keyConfig;


    /// <summary>
    /// 上下左右入力をVec2で取得
    /// </summary>
    public Vector3 arrow
    {
        get
        {
            Vector3 vec = new Vector3();
            if (up) vec.y += 1;
            if (down) vec.y += -1;
            if (right) vec.x += 1;
            if (left) vec.x += -1;
            return vec;
        }
    }
    /// <summary>
    /// 攻撃
    /// </summary>
    public bool fire { private set; get; }
    /// <summary>
    /// 加速
    /// </summary>
    public bool accel { private set; get; }
    /// <summary>
    /// 減速
    /// </summary>
    public bool decel { private set; get; }
    /// <summary>
    /// 上方向入力
    /// </summary>
    public bool up { get; private set; }
    /// <summary>
    /// 下方向入力
    /// </summary>
    public bool down { get; private set; }
    /// <summary>
    /// 右方向入力
    /// </summary>
    public bool right { get; private set; }
    /// <summary>
    /// 左方向入力
    /// </summary>
    public bool left { get; private set; }
    /// <summary>
    /// マップ表示入力
    /// </summary>
    public bool map { get; private set; }
    /// <summary>
    /// 部隊編成表示入力
    /// </summary>
    public bool squad { get; private set; }

    void Start()
    {
        if (keyConfig == null) Debug.LogError("InputKeyConfigを設定してください");
    }

    void Update()
    {
        HoldKeys();
        SwitchKeys();
    }
    /// <summary>
    /// 押しっぱなしキー
    /// </summary>
    private void HoldKeys()
    {
        up = Input.GetKey(keyConfig.up);
        down = Input.GetKey(keyConfig.down);
        left = Input.GetKey(keyConfig.left);
        right = Input.GetKey(keyConfig.right);
        fire = Input.GetKey(keyConfig.fire);
        accel = Input.GetKey(keyConfig.accel);
        decel = Input.GetKey(keyConfig.decel);
    }
    /// <summary>
    /// 押したら切り替えキー
    /// </summary>
    private void SwitchKeys()
    {
        if (Input.GetKeyDown(keyConfig.map))
        {
            map = !map;
        }
        if (Input.GetKeyDown(keyConfig.squad))
        {
            squad = !squad;
        }
    }
}

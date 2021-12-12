using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputs : MonoBehaviour
{
    [SerializeField]
    private InputKeyManager keyManager;
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
    public bool fire { private set; get; }
    public bool accel { private set; get; }
    public bool decel { private set; get; }
    public bool up { get; private set; }
    public bool down { get; private set; }
    public bool right { get; private set; }
    public bool left { get; private set; }
    public bool map { get; private set; }
    public bool squad { get; private set; }

    void Start()
    {
        if (keyManager == null) Debug.LogError("InputKeyManagerを設定してください");
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
        up = Input.GetKey(keyManager.up);
        down = Input.GetKey(keyManager.down);
        left = Input.GetKey(keyManager.left);
        right = Input.GetKey(keyManager.right);
        fire = Input.GetKey(keyManager.fire);
        accel = Input.GetKey(keyManager.accel);
        decel = Input.GetKey(keyManager.decel);
    }
    /// <summary>
    /// 押したら切り替えキー
    /// </summary>
    private void SwitchKeys()
    {
        if (Input.GetKeyDown(keyManager.map))
        {
            map = !map;
        }
        if (Input.GetKeyDown(keyManager.squad))
        {
            squad = !squad;
        }
    }
}

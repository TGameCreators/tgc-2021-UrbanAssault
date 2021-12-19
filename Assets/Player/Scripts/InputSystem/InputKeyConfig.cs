using UnityEngine;
//fileName	このタイプの新しく作成されるインスタンスで使用するデフォルトのファイル名
//menuName Assets/Create メニューに表示されるこのタイプの表示名
//order	Assets/Create メニュー内のメニューアイテムの位置
[CreateAssetMenu(fileName = "defaultKeyConfig", menuName = "ScriptableObjects/InputKeyConfig", order = 1)]
public class InputKeyConfig : ScriptableObject
{
    [SerializeField, Tooltip("上方向")] private KeyCode Up = KeyCode.UpArrow;
    [SerializeField, Tooltip("下方向")] private KeyCode Down = KeyCode.DownArrow;
    [SerializeField, Tooltip("左方向")] private KeyCode Left = KeyCode.LeftArrow;
    [SerializeField, Tooltip("右方向")] private KeyCode Right = KeyCode.RightArrow;
    [SerializeField, Tooltip("攻撃ボタン")] private KeyCode Fire = KeyCode.Space;
    [SerializeField, Tooltip("加速ボタン")] private KeyCode Accel = KeyCode.A;
    [SerializeField, Tooltip("減速ボタン")] private KeyCode Decel = KeyCode.Z;
    [SerializeField, Tooltip("マップ表示")] private KeyCode Map = KeyCode.M;
    [SerializeField, Tooltip("部隊編成表示")] private KeyCode Squad = KeyCode.S;
    public KeyCode up => Up;
    public KeyCode down => Down;
    public KeyCode left => Left;
    public KeyCode right => Right;
    public KeyCode fire => Fire;
    public KeyCode accel => Accel;
    public KeyCode decel => Decel;
    public KeyCode map => Map;
    public KeyCode squad => Squad;
}

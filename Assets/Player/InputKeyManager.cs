using UnityEngine;
//fileName	このタイプの新しく作成されるインスタンスで使用するデフォルトのファイル名
//menuName Assets/Create メニューに表示されるこのタイプの表示名
//order	Assets/Create メニュー内のメニューアイテムの位置
[CreateAssetMenu(fileName = "defaultKeyBind", menuName = "ScriptableObjects/InputKeyManager", order = 1)]
public class InputKeyManager : ScriptableObject
{
    [SerializeField] private KeyCode Up = KeyCode.UpArrow;
    [SerializeField] private KeyCode Down = KeyCode.DownArrow;
    [SerializeField] private KeyCode Left = KeyCode.LeftArrow;
    [SerializeField] private KeyCode Right = KeyCode.RightArrow;
    [SerializeField] private KeyCode Fire = KeyCode.Space;
    [SerializeField] private KeyCode Accel = KeyCode.A;
    [SerializeField] private KeyCode Decel = KeyCode.Z;
    [SerializeField] private KeyCode Map = KeyCode.M;
    [SerializeField] private KeyCode Squad = KeyCode.S;
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

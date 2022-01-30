using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HitPoint : MonoBehaviour
{
    [SerializeField]
    private int maxHP = 100;
    private int currentHP;

    UnityEvent Damaged, Dead;

    void Start()
    {
        currentHP = maxHP;
    }

    /// <summary>
    /// 回復させる
    /// </summary>
    /// <param name="heal">回復させる量（1以上の正数）</param>
    /// <returns>実際の回復後</returns>
    public int Heal(int heal)
    {
        currentHP += heal;
        currentHP = Mathf.Min(currentHP, maxHP);
        return heal;
    }

    /// <summary>
    /// ダメージを与える
    /// </summary>
    /// <param name="damage">ダメージ量（1以上の正数）</param>
    /// <returns>実際のダメージ量</returns>
    public int Damage(int damage)
    {
        currentHP -= damage;
        Damaged.Invoke();
        if (currentHP <= 0) Death();
        return damage;
    }

    public void Death()
    {
        Dead.Invoke();
    }
}

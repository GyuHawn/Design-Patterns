using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : Unit
{
    public override string[] inforUnitState()
    {
        string[] state = new string[4]; // 상태 데이터가 현재 4개 

        state[0] = unitName;
        state[1] = level.ToString();
        state[2] = hp.ToString();
        state[3] = damage.ToString();

        return state;   
    }

    public override void StateUpdate(SettingDatas settingDatas)
    {
        level += settingDatas.slodierLevel;
        hp += settingDatas.slodierHP;
        damage += settingDatas.slodierDamage;
    }

    public override void Hip(int damage)
    {
        hp -= damage;

        Debug.Log("솔져 체력 : " + hp);
    }

    public override void UnitDestory()
    {
        Destroy(gameObject);
    }

    public override void SumState()
    {
        level += 1;
        hp += 2;
        damage += 1;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UnitType
{
    Soldier,
    Flight
}

public abstract class Unit : MonoBehaviour // �߻� Ŭ���� abstract
{
    // ���� ����
    public string unitName;
    public int level;
    public int hp;
    public int damage;

    public abstract string[] inforUnitState(); // UI ���� ǥ��
    public abstract void StateUpdate(SettingDatas settingDatas); // ���� ������ �����Ͽ� ����

    public abstract void Hip(int damage); // �¾����� ó��
    public abstract void UnitDestory(); // ����� ����
    public abstract void SumState(); // ������ �� ���°� ����
}


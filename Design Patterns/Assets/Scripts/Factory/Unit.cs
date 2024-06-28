using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UnitType
{
    Soldier,
    Flight
}

public abstract class Unit : MonoBehaviour // 추상 클래스 abstract
{
    // 유닛 정보
    public string unitName;
    public int level;
    public int hp;
    public int damage;

    public abstract string[] inforUnitState(); // UI 정보 표시
    public abstract void StateUpdate(SettingDatas settingDatas); // 상태 변경을 적용하여 적용

    public abstract void Hip(int damage); // 맞았을때 처리
    public abstract void UnitDestory(); // 사망시 삭제
    public abstract void SumState(); // 레벨업 시 상태값 증가
}


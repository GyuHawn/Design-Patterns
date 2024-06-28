using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    [SerializeField] private GameObject[] soldier;
    [SerializeField] private GameObject[] flight;

    // ������ ���� ����
    public List<GameObject> soldierList = new List<GameObject>();
    public List<GameObject> flightList = new List<GameObject>();

    // �������� ������ ������  
    SettingDatas settingDatas = new SettingDatas();

    // ���� ����
    public void MakeUnit(UnitType unitType)
    {
        GameObject obj = null;

        switch (unitType)
        {
            case UnitType.Soldier:
                {
                    int random = Random.Range(0, soldier.Length);
                    obj = Instantiate(soldier[random], new Vector3(0, 0.5f, 0), Quaternion.identity);
                    obj.GetComponent<Soldier>().StateUpdate(settingDatas);

                    soldierList.Add(obj);
                }
                break;
            case UnitType.Flight:
                {
                    int random = Random.Range(0, flight.Length);
                    obj = Instantiate(flight[random], new Vector3(0, 0.5f, 0), Quaternion.identity);
                    obj.GetComponent<Flight>().StateUpdate(settingDatas);

                    flightList.Add(obj);
                }
                break;
        }
    }
    
    // ���� �ǰ�
    public void SoldierHit(RaycastHit hit)
    {
        Soldier soldier = hit.collider.gameObject.GetComponent<Soldier>();

        soldier.Hip(1);

        if(soldier.hp <= 0)
        {
            soldierList.Remove(hit.collider.gameObject);
            soldier.UnitDestory();
        }
    }
    public void FlightHit(RaycastHit hit)
    {
        Flight flight = hit.collider.gameObject.GetComponent<Flight>();

        flight.Hip(1);

        if (flight.hp <= 0)
        {
            flightList.Remove(hit.collider.gameObject);
            flight.UnitDestory();
        }
    }

    // ��ȯ���� ���� ���ݾ�
    public void SoldierLevelUP()
    {
        foreach(var soldier in soldierList)
        {
            soldier.GetComponent<Soldier>().SumState();
        }
        SolfierDataUpdate(ref settingDatas.slodierLevel, ref settingDatas.slodierHP, ref settingDatas.slodierDamage);
    }
    public void FlightLevelUP()
    {
        foreach (var flight in flightList)
        {
            flight.GetComponent<Flight>().SumState();
        }
        FlightrDataUpdate(ref settingDatas.flightLevel, ref settingDatas.flightHP, ref settingDatas.flightDamage);
    }
    
    // ��ȯ���� ���� ���� ���ݾ�
    private void SolfierDataUpdate(ref int lv, ref int hp, ref int damage)
    {
        lv += 1;
        hp += 2;
        damage += 1;
    }
    private void FlightrDataUpdate(ref int lv, ref int hp, ref int damage)
    {
        lv += 1;
        hp += 3;
        damage += 2;
    }
}

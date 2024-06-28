using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GamaManager : MonoBehaviour
{
    [SerializeField] GameObject stateWindow;
    [SerializeField] TMP_Text textName;
    [SerializeField] TMP_Text textLv;
    [SerializeField] TMP_Text textHP;
    [SerializeField] TMP_Text textDamage;

    UnitManager unitManager;

    private void Start()
    {
        Init();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            InfoUnitState();
        }
        else if (Input.GetMouseButtonDown(1))
        {
            HitUnit();
        }
    }

    private void Init()
    {
        unitManager = GetComponent<UnitManager>();
        stateWindow.SetActive(false);
    }

    // 유닛 클릭시 정보표시
    private void InfoUnitState() 
    {
        RaycastHit hit;
        Physics.Raycast(ClickPosition(), out hit);

        if (hit.collider.CompareTag("Soldier"))
        {
            ShowStateInUI(hit.collider.gameObject.GetComponent<Soldier>().inforUnitState());
        }
        else if (hit.collider.CompareTag("Flight"))
        {
            ShowStateInUI(hit.collider.gameObject.GetComponent<Flight>().inforUnitState());
        }
    }

    private void ShowStateInUI(string[] state)
    {
        textName.text = "Name : " + state[0];
        textLv.text = "Lv : " + state[1];
        textHP.text = "HP : " + state[2];
        textDamage.text = "Damage : " + state[3];

        stateWindow.SetActive(true); 
    }

    public void UnitSpawnButton(int type)
    {
        switch (type)
        {
            case 0:
                {
                    unitManager.MakeUnit(UnitType.Soldier);
                }
                break;
            case 1:
                {
                    unitManager.MakeUnit(UnitType.Flight);
                }
                break;
        }
    }

    // 유닛 클릭시 공격
    private void HitUnit()
    {
        RaycastHit hit;
        Physics.Raycast(ClickPosition(), out hit);

        if (hit.collider.CompareTag("Soldier"))
        {
            unitManager.SoldierHit(hit);
        }
        else if (hit.collider.CompareTag("Flight"))
        {
            unitManager.FlightHit(hit);
        }
    }

    // 마우스 클릭
    private Ray ClickPosition()
    {
        return Camera.main.ScreenPointToRay(Input.mousePosition);
    }

    // 유닛 레벨업
    public void SoldierLevelUpButton()
    {
        unitManager.SoldierLevelUP();
    }
    public void FlightLevelUpButton()
    {
        unitManager.FlightLevelUP();
    }
}

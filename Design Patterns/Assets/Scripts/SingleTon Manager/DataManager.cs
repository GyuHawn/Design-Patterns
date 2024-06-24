using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : SingleTone<DataManager> // 싱글톤 클래스 상속받기 ("SingleTon"이란 이름의 Script)
{
    public void Save()
    {
        Debug.Log("저장완료");
    }
}

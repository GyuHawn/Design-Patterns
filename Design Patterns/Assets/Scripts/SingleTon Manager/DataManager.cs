using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : SingleTone<DataManager> // �̱��� Ŭ���� ��ӹޱ� ("SingleTon"�̶� �̸��� Script)
{
    public void Save()
    {
        Debug.Log("����Ϸ�");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCube : MonoBehaviour
{  
    void Start()
    {
        StartCoroutine(CreateCubes());   
    }

    // ���������� ť�� ����
    IEnumerator CreateCubes()
    {
        while (true)
        {
            yield return null;
            // Ǯ���� ť�긦 ������
            GameObject cube = PoolingManager.Instance.GetQueue();
            // ť���� ��ġ�� ��������
            cube.transform.position = Vector3.zero;
        }
    }
}

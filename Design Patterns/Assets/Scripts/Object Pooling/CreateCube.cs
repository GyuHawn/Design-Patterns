using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCube : MonoBehaviour
{  
    void Start()
    {
        StartCoroutine(CreateCubes());   
    }

    // 지속적으로 큐브 생성
    IEnumerator CreateCubes()
    {
        while (true)
        {
            yield return null;
            // 풀에서 큐브를 가져옴
            GameObject cube = PoolingManager.Instance.GetQueue();
            // 큐브의 위치를 원점으로
            cube.transform.position = Vector3.zero;
        }
    }
}

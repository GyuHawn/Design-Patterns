using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    Rigidbody cubeRigid;

    private void OnEnable()
    {
        // 큐브에 리지드바디를 할당하지 않았다면 가져오기
        if(cubeRigid == null)
        {
            cubeRigid = GetComponent<Rigidbody>();
        }

        // 리지드바디 속도 초기화
        cubeRigid.velocity = Vector3.zero;
        // 큐브에 폭발력 추가
        cubeRigid.AddExplosionForce(100, transform.position, 1f);

        StartCoroutine(DestroyCube());
    }

    // 큐브 파과
    IEnumerator DestroyCube()
    {
        yield return new WaitForSeconds(1f);
        // 큐브를 다시 풀에 삽입
        PoolingManager.Instance.InsertQueue(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    Rigidbody cubeRigid;

    private void OnEnable()
    {
        // ť�꿡 ������ٵ� �Ҵ����� �ʾҴٸ� ��������
        if(cubeRigid == null)
        {
            cubeRigid = GetComponent<Rigidbody>();
        }

        // ������ٵ� �ӵ� �ʱ�ȭ
        cubeRigid.velocity = Vector3.zero;
        // ť�꿡 ���߷� �߰�
        cubeRigid.AddExplosionForce(100, transform.position, 1f);

        StartCoroutine(DestroyCube());
    }

    // ť�� �İ�
    IEnumerator DestroyCube()
    {
        yield return new WaitForSeconds(1f);
        // ť�긦 �ٽ� Ǯ�� ����
        PoolingManager.Instance.InsertQueue(gameObject);
    }
}

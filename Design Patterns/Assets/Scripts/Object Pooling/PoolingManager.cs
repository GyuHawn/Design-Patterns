using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingManager : MonoBehaviour
{
    // �̱��� �ν��Ͻ�, Ǯ�� �Ŵ��� ���� ���� ���
    public static PoolingManager Instance;
    
    // ������ ť�� ������
    public GameObject cubePrifab;

    // ��Ȱ��ȭ�� ť�긦 ������ ť
    public Queue<GameObject> queue = new Queue<GameObject>();

    void Start()
    {
        // �̱��� �ν��Ͻ� �ʱ�ȭ
        Instance = this;
        
        // 500���� ť�� ����
        for (int i = 0; i < 500; i++)
        {
            // �������� ť�� ����
            GameObject cube = Instantiate(cubePrifab, Vector3.zero, Quaternion.identity);
            // ������ ť�긦 ť�� ����
            queue.Enqueue(cube);
            // ť�� ��Ȱ��ȭ
            cube.SetActive(false);
        }
    }

    // ť�긦 Ǯ�� �ٽ� ����
    public void InsertQueue(GameObject cube)
    {
        queue.Enqueue(cube); // Enqueue - ť�� ���� �߰�
        cube.SetActive(false);
    }

    // Ǯ���� ť�긦 ������
    public GameObject GetQueue()
    {
        // Ǯ���� ť�긦 ����
        GameObject cube = queue.Dequeue(); // Dequeue - ť�� ���� ���� ������ ����
        // ť�� Ȱ��ȭ
        cube.SetActive(true);
        return cube;
    }
}

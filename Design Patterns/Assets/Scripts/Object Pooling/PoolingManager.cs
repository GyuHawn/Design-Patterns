using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingManager : MonoBehaviour
{
    // 싱글톤 인스턴스, 풀링 매니저 전역 접근 허용
    public static PoolingManager Instance;
    
    // 생성할 큐브 프리팹
    public GameObject cubePrifab;

    // 비활성화된 큐브를 보관할 큐
    public Queue<GameObject> queue = new Queue<GameObject>();

    void Start()
    {
        // 싱글톤 인스턴스 초기화
        Instance = this;
        
        // 500개의 큐브 생성
        for (int i = 0; i < 500; i++)
        {
            // 프리팹의 큐브 생성
            GameObject cube = Instantiate(cubePrifab, Vector3.zero, Quaternion.identity);
            // 생성한 큐브를 큐에 저장
            queue.Enqueue(cube);
            // 큐브 비활성화
            cube.SetActive(false);
        }
    }

    // 큐브를 풀에 다시 삽입
    public void InsertQueue(GameObject cube)
    {
        queue.Enqueue(cube); // Enqueue - 큐의 끝에 추가
        cube.SetActive(false);
    }

    // 풀에서 큐브를 가져옴
    public GameObject GetQueue()
    {
        // 풀에서 큐브를 꺼냄
        GameObject cube = queue.Dequeue(); // Dequeue - 큐의 가장 앞의 데이터 제거
        // 큐브 활성화
        cube.SetActive(true);
        return cube;
    }
}

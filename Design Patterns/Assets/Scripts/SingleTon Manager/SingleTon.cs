using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 제네릭 싱글톤 클래스 정의
public class SingleTone<T> : MonoBehaviour where T : MonoBehaviour
{
    // 싱글톤 인스턴스를 저장하는 정적 변수
    private static T instance;

    // 싱글톤 인스턴스를 반환하는 정적 프로퍼티
    public static T Instance
    {
        get
        {
            // 인스턴스가 null이면 씬에서 해당 타입의 오브젝트를 찾는다
            if(instance == null)
            {
                instance = (T)FindObjectOfType(typeof(T));

                // 여전히 인스턴스가 null이면 새로운 게임 오브젝트를 생성하고 T 컴포넌트를 추가
                if(instance == null)
                {
                    // 새로운 게임 오브젝트 생성
                    GameObject obj = new GameObject(typeof(T).Name, typeof(T));
                    // T 컴포넌트 추가 후 인스턴스로 설정
                    instance = obj.AddComponent<T>();
                }
            }
            return instance; // 싱글톤 인스턴스 반환
        }
    }

    private void Awake()
    {
        // 인스턴스가 null이면 현재 오브젝트를 DontDestroyOnLoad로 설정(씬이 넘어가도 제거되지 않도록)
        if (instance == null)
        {
            // 부모 오브젝트가 있으면 최상위 보모 오브젝트를 DontDestroyOnLoad로 설정
            if (transform.parent != null && transform.root != null)
            {
                DontDestroyOnLoad(this.transform.root.gameObject);
            }
            else
            {
                // 부모 오브젝트가 없을시 현재 오브젝트를 DontDestroyOnLoad로 설정
                DontDestroyOnLoad(this.gameObject); 
            }
        }
        // 인스턴스가 이미 존재하고, 현재 오브젝트와 다르면 현재 오브젝트를 파괴
        else if (instance != this)
        {
            // 중복된 싱글톤 오브젝트 파괴
            Destroy(this.gameObject);
        }
    }
}

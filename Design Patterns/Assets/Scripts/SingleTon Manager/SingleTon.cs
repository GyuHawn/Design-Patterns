using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���׸� �̱��� Ŭ���� ����
public class SingleTone<T> : MonoBehaviour where T : MonoBehaviour
{
    // �̱��� �ν��Ͻ��� �����ϴ� ���� ����
    private static T instance;

    // �̱��� �ν��Ͻ��� ��ȯ�ϴ� ���� ������Ƽ
    public static T Instance
    {
        get
        {
            // �ν��Ͻ��� null�̸� ������ �ش� Ÿ���� ������Ʈ�� ã�´�
            if(instance == null)
            {
                instance = (T)FindObjectOfType(typeof(T));

                // ������ �ν��Ͻ��� null�̸� ���ο� ���� ������Ʈ�� �����ϰ� T ������Ʈ�� �߰�
                if(instance == null)
                {
                    // ���ο� ���� ������Ʈ ����
                    GameObject obj = new GameObject(typeof(T).Name, typeof(T));
                    // T ������Ʈ �߰� �� �ν��Ͻ��� ����
                    instance = obj.AddComponent<T>();
                }
            }
            return instance; // �̱��� �ν��Ͻ� ��ȯ
        }
    }

    private void Awake()
    {
        // �ν��Ͻ��� null�̸� ���� ������Ʈ�� DontDestroyOnLoad�� ����(���� �Ѿ�� ���ŵ��� �ʵ���)
        if (instance == null)
        {
            // �θ� ������Ʈ�� ������ �ֻ��� ���� ������Ʈ�� DontDestroyOnLoad�� ����
            if (transform.parent != null && transform.root != null)
            {
                DontDestroyOnLoad(this.transform.root.gameObject);
            }
            else
            {
                // �θ� ������Ʈ�� ������ ���� ������Ʈ�� DontDestroyOnLoad�� ����
                DontDestroyOnLoad(this.gameObject); 
            }
        }
        // �ν��Ͻ��� �̹� �����ϰ�, ���� ������Ʈ�� �ٸ��� ���� ������Ʈ�� �ı�
        else if (instance != this)
        {
            // �ߺ��� �̱��� ������Ʈ �ı�
            Destroy(this.gameObject);
        }
    }
}

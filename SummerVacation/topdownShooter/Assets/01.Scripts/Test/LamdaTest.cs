using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LamdaTest : MonoBehaviour
{
    //��������Ʈ (�븮��)
    public delegate void Add(int a, int b);
    public Add b;

    public delegate int Add4(int a);
    public Add4 c;

    private List<GameObject> list = new List<GameObject>();

    private void Start()
    {
        /*b = GGM;
        b += GGM2;
        b -= GGM2;
        b(2, 3);*/

        b = delegate (int a, int b)
        {
            Debug.Log(a + b);
        };

        b = (a, b) => Debug.Log(a + b);

        c = a => a + 4;

        List<GameObject> activeList = list.FindAll(x => x.activeSelf);

        //�̸��� ���� �Լ��� => �͸��Լ�
        //���� ǥ����
        /*
         * 1. delegate�� �����ϰ� �Ұ�ȣ�� �߰�ȣ ���̿� => �� �ִ´�
         * 2. �Ķ���Ϳ� �ִ� ����Ÿ���� ������ �����ϴ�
         * 3. ���ٷ� �̷���� �Լ��� (return ������ ����) �߰�ȣ���� ���������ϴ�
         * 4. �Ķ���Ͱ� �Ѱ��� ��� �Ķ���͸� �ѱ�� �Ұ�ȣ�� ���� �����ϴ�
         */
    }

    public void GGM(int first, int second)
    {
        Debug.Log(first + second);
    }
    public void GGM2(int first, int second)
    {
        Debug.Log(first + second + 10);
    }
}

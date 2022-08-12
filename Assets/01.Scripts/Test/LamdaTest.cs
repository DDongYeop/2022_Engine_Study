using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LamdaTest : MonoBehaviour
{
    //델리게이트 (대리자)
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

        //이름이 없는 함수란 => 익명함수
        //람다 표현식
        /*
         * 1. delegate를 제거하고 소괄호와 중괄호 사이에 => 를 넣는다
         * 2. 파라메터에 있는 변수타입은 생략이 가능하다
         * 3. 한줄로 이루어진 함수는 (return 문까지 포함) 중괄호까지 생략가능하다
         * 4. 파라메터가 한개일 경우 파라메터를 넘기는 소괄호도 생략 가능하다
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

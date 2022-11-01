using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���콺 �Է¿� ���� ī�޶� ȸ����Ű�� �ʹ�
// �ʿ� �Ӽ�: ���簢��, ���콺 ����
public class CamRotate : MonoBehaviour
{
    Vector3 angle; //���� ����
    public float sensitivity = 200;

    private void Start()
    {
        // ������ �� ���� ī�޶��� ������ �����Ѵ�
        angle.y = -Camera.main.transform.position.x;
        angle.x = Camera.main.transform.position.y;
        angle.z = Camera.main.transform.position.z;
    }

    private void Update()
    {
        // ���콺 �Է¿� ���� ī�޶� ȸ����Ű�� �ʹ�
        // 1. ������� ���콺 �Է��� ���;��Ѵ�
        // ���콺�� �¿� �Է��� �޴´�
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");

        // 2. ������ �ʿ��ϴ�
        // �̵� ���Ŀ� ������ �� �Ӽ����� ȸ�� ���� ������Ų��
        angle.x += x * sensitivity * Time.deltaTime;
        angle.y += y * sensitivity * Time.deltaTime;

        // 3. ȸ�� ��Ű�� �ʹ�
        // ī�޶��� ȸ�� ���� ���� ������� ȸ�� ���� �Ҵ��Ѵ�
        transform.eulerAngles = new Vector3(-angle.y, angle.x, transform.eulerAngles.z);
    }
}

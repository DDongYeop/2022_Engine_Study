#define PC
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARVRInput : MonoBehaviour
{
    public enum ButtonTarget
    {
#if PC
        Fire1,
        Fire2,
        Fire3,
        Jump,
#endif
    }

    public enum Button
    {
#if PC
        One = ButtonTarget.Fire1,
        Two = ButtonTarget.Jump,
        Thumbstick = ButtonTarget.Fire1,
        IndexTrigger = ButtonTarget.Fire3,
        HandTrigger = ButtonTarget.Fire2
#endif
    }

    public enum Controller
    {
#if PC
        LTouch,
        RTouch
#endif
    }

    public static Vector3 RHandPosition  // ������ ��Ʈ�ѷ��� ��ġ ������
    {
        get
        {
#if PC
            Vector3 pos = Input.mousePosition; //���콺�� ��ũ�� ��ǥ ������
            pos.z = 0.7f; //z ���� 0.7m�� ����
            pos = Camera.main.ScreenToWorldPoint(pos); //��ũ�� ��ǥ�� ���� ��ǥ�� ��ȯ
            return pos;
#endif
        }
    }

    public static Vector3 RHandDirection // ������ ��Ʈ�ѷ��� ���� ������
    {
        get
        {
#if PC
            Vector3 direction = RHandPosition - Camera.main.transform.position;
            RHand.forward = direction;
            return direction;
#endif
        }
    }

    public static Vector3 LHandPosition  //   ���� ����ѷ��� ��ġ ������
    {
        get
        {
#if PC
            Vector3 pos = Input.mousePosition; //���콺�� ��ũ�� ��ǥ ������
            pos.z = 0.7f; //z ���� 0.7m�� ����
            pos = Camera.main.ScreenToWorldPoint(pos); //��ũ�� ��ǥ�� ���� ��ǥ�� ��ȯ
            return pos;
#endif
        }
    }

    public static Vector3 LHandDirection //   ���� ��Ʈ�ѷ��� ���� ������
    {
        get
        {
#if PC
            Vector3 direction = RHandPosition - Camera.main.transform.position;
            RHand.forward = direction;
            return direction;
#endif
        }
    }

    static Transform lHand;
    public static Transform LHand        // ���� ��ϵ� ���� ��Ʈ�ѷ� ã�� ��ȯ�ϱ�
    {
        get
        {
            if (lHand == null)
            {
#if PC
                GameObject handObj = new GameObject("lHand"); // LHand��� �̸����� ���� ������Ʈ�� �����
                lHand = handObj.transform; // ������� ��ü�� Ʈ�������� lHand�� �Ҵ�
                lHand.parent = Camera.main.transform;
#endif
            }
            return lHand;
        }
    }

    static Transform rHand;
    public static Transform RHand        // ���� ��ϵ� ������ ��Ʈ�ѷ� ã�� ��ȯ�ϱ�
    {
        get
        {
            if (lHand == null)
            {
                GameObject handObj = new GameObject("rHand"); // RHand��� �̸����� ���� ������Ʈ�� �����
                rHand = handObj.transform; // ������� ��ü�� Ʈ�������� rHand�� �Ҵ�
                rHand.parent = Camera.main.transform;
            }
            return lHand;
        }
    }

    public static bool Get(Button virtualMask, Controller hand = Controller.RTouch) //��Ʈ�ѷ��� Ư�� ��ư�� ������ �ִ� ���� true�� ��ȯ
    {
#if PC
        return Input.GetButton(((ButtonTarget)virtualMask).ToString()); //virtualMask�� ���� ���� ButtonTargetŸ������ ��ȯ�� �����Ѵ�
#endif
    }

    public static bool GetDown(Button virtualMask, Controller hand = Controller.RTouch) //��Ʈ�ѷ��� Ư����ư�� ������ �� true�� ��ȯ
    {
#if PC
        return Input.GetButton(((ButtonTarget)virtualMask).ToString());
#endif
    }

    public static bool GetUp(Button virtualMask, Controller hand = Controller.RTouch) //��Ʈ�ѷ��� Ư�� ��ư�� ������ ������ �� true��ȯ
    {
#if PC
        return Input.GetButtonDown(((ButtonTarget)virtualMask).ToString());
#endif
    }

    // ��Ʈ�ѷ��� Axis �Է��� ��ȯ
    // axis: Horizontal, Vertical ���� ���´�.
    public static float GetAxis(string axis, Controller hand = Controller.LTouch)
    {
#if PC
        return Input.GetAxis(axis);
#endif
    }

    public static void PlayVibration(Controller hand) // ��Ʈ�ѷ��� ���� ȣ���ϱ�
    {

    }

    // ī�޶� �ٶ󺸴� ������ �������� ���͸� ��´�
    public static void Recenter(Transform target, Vector3 direction) //���ϴ� �������� Ÿ���� ���͸� ����
    {
        target.forward = target.rotation * direction;
    }

#if PC
        static Vector3 originScale = Vector3.one;
#endif

    public static void DrawCrosshair(Transform crosshair, bool isHand = true, Controller hand = Controller.RTouch) //���� ���̰� ��� ���� ũ�ν��� ��ġ�ϰ� �ʹ�
    {

        Ray ray;
        //��Ʈ�ѷ��� ��ġ�� ������ �̿��� ���� ����
        if (isHand)
        {
#if PC
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
#endif
        }
        else
        {
            //ī�޶� �������� ȭ���� ���߾����� ���̸� ����
            ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        }

        Plane plane = new Plane(Vector3.up, 0);
        float distance = 0;
        if (plane.Raycast(ray, out distance)) //plane�� �̿���  ray�� ���
        {
            //������ GetPoint �Լ��� �̿��� �浹 ������ ��ġ�� �����´�
            crosshair.position = ray.GetPoint(distance);
            crosshair.forward = -Camera.main.transform.forward;
            //ũ�ν������ ũ�⸦ �ּ� �⺻ ũ�⿡�� �Ÿ��� ���� �� Ŀ������ �Ѵ�
            crosshair.localScale = originScale * Mathf.Max(1, distance);
        }
        else
        {
            crosshair.position = ray.origin + ray.direction * 100;
            crosshair.forward = -Camera.main.transform.forward;
            distance = (crosshair.position-ray.origin).magnitude;
            crosshair.localScale = originScale * Mathf.Max(1, distance);
        }
    }
}

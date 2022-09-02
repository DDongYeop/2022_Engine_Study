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

    public static Vector3 RHandPosition  // 오른쪽 컨트롤러의 위치 얻어오기
    {
        get
        {
#if PC
            Vector3 pos = Input.mousePosition; //마우스의 스크린 좌표 얻어오기
            pos.z = 0.7f; //z 값은 0.7m로 설정
            pos = Camera.main.ScreenToWorldPoint(pos); //스크린 좌표를 월드 좌표로 변환
            return pos;
#endif
        }
    }

    public static Vector3 RHandDirection // 오른쪽 컨트롤러의 방향 얻어오기
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

    public static Vector3 LHandPosition  //   왼쪽 컨드롤러의 위치 얻어오기
    {
        get
        {
#if PC
            Vector3 pos = Input.mousePosition; //마우스의 스크린 좌표 얻어오기
            pos.z = 0.7f; //z 값은 0.7m로 설정
            pos = Camera.main.ScreenToWorldPoint(pos); //스크린 좌표를 월드 좌표로 변환
            return pos;
#endif
        }
    }

    public static Vector3 LHandDirection //   왼쪽 컨트롤러의 방향 얻어오기
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
    public static Transform LHand        // 씬에 등록된 왼쪽 컨트롤러 찾아 반환하기
    {
        get
        {
            if (lHand == null)
            {
#if PC
                GameObject handObj = new GameObject("lHand"); // LHand라는 이름으로 게임 오브젝트를 만든다
                lHand = handObj.transform; // 만들어진 객체의 트랜스폼을 lHand에 할당
                lHand.parent = Camera.main.transform;
#endif
            }
            return lHand;
        }
    }

    static Transform rHand;
    public static Transform RHand        // 씬에 등록된 오른쪽 컨트롤러 찾아 반환하기
    {
        get
        {
            if (lHand == null)
            {
                GameObject handObj = new GameObject("rHand"); // RHand라는 이름으로 게임 오브젝트를 만든다
                rHand = handObj.transform; // 만들어진 객체의 트랜스폼을 rHand에 할당
                rHand.parent = Camera.main.transform;
            }
            return lHand;
        }
    }

    public static bool Get(Button virtualMask, Controller hand = Controller.RTouch) //컨트롤러의 특정 버튼을 누르고 있는 동안 true를 변환
    {
#if PC
        return Input.GetButton(((ButtonTarget)virtualMask).ToString()); //virtualMask에 들어온 값을 ButtonTarget타입으로 변환해 전달한다
#endif
    }

    public static bool GetDown(Button virtualMask, Controller hand = Controller.RTouch) //컨트롤러의 특정버튼을 눌렀을 때 true를 변환
    {
#if PC
        return Input.GetButton(((ButtonTarget)virtualMask).ToString());
#endif
    }

    public static bool GetUp(Button virtualMask, Controller hand = Controller.RTouch) //컨트롤러의 특정 버튼을 눌렀다 떼었을 때 true변환
    {
#if PC
        return Input.GetButtonDown(((ButtonTarget)virtualMask).ToString());
#endif
    }

    // 컨트롤러의 Axis 입력을 반환
    // axis: Horizontal, Vertical 값을 갖는다.
    public static float GetAxis(string axis, Controller hand = Controller.LTouch)
    {
#if PC
        return Input.GetAxis(axis);
#endif
    }

    public static void PlayVibration(Controller hand) // 컨트롤러에 진동 호출하기
    {

    }

    // 카메라가 바라보는 방향을 기준으로 센터를 잡는다
    public static void Recenter(Transform target, Vector3 direction) //원하는 방향으로 타깃의 센터를 설정
    {
        target.forward = target.rotation * direction;
    }

#if PC
        static Vector3 originScale = Vector3.one;
#endif

    public static void DrawCrosshair(Transform crosshair, bool isHand = true, Controller hand = Controller.RTouch) //광선 레이가 닿는 곳에 크로스헤어를 위치하고 싶다
    {

        Ray ray;
        //컨트롤러의 위치와 방향을 이용해 레이 제작
        if (isHand)
        {
#if PC
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
#endif
        }
        else
        {
            //카메라 기준으로 화면의 정중앙으로 레이를 제작
            ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        }

        Plane plane = new Plane(Vector3.up, 0);
        float distance = 0;
        if (plane.Raycast(ray, out distance)) //plane을 이용해  ray를 쏜다
        {
            //레이의 GetPoint 함수를 이용해 충돌 지점의 위치를 가져온다
            crosshair.position = ray.GetPoint(distance);
            crosshair.forward = -Camera.main.transform.forward;
            //크로스헤어의 크기를 최소 기본 크기에서 거리에 따라 더 커지도록 한다
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ViveInputTest : MonoBehaviour
{
    private void Update()
    {
        SteamVR_Input_Sources hand = SteamVR_Input_Sources.LeftHand;
        bool state = SteamVR_Actions._default.Teleport[hand].state; // 1. 액션 셋에 직접 접근한 입력
        state = SteamVR_Actions.default_Teleport[hand].state;       // 2. 액션 셋_액션을 이용한 입력
        state = SteamVR_Input.GetState(" Teleport ", hand);         // 3. SteamVR_Input.GetState()을 이용한 입력

        // 4. SteamVR_Input.SteamVR_Action()을 이용한 입력
        SteamVR_Action_Boolean action = SteamVR_Input.GetBooleanAction(" Teleport ");
        state = action.GetState(hand);
    }

}

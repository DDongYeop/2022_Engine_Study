using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ViveInputTest : MonoBehaviour
{
    private void Update()
    {
        SteamVR_Input_Sources hand = SteamVR_Input_Sources.LeftHand;
        bool state = SteamVR_Actions._default.Teleport[hand].state; // 1. �׼� �¿� ���� ������ �Է�
        state = SteamVR_Actions.default_Teleport[hand].state;       // 2. �׼� ��_�׼��� �̿��� �Է�
        state = SteamVR_Input.GetState(" Teleport ", hand);         // 3. SteamVR_Input.GetState()�� �̿��� �Է�

        // 4. SteamVR_Input.SteamVR_Action()�� �̿��� �Է�
        SteamVR_Action_Boolean action = SteamVR_Input.GetBooleanAction(" Teleport ");
        state = action.GetState(hand);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AITransition : MonoBehaviour
{
    public List<AIDecision> decisions; // 결정 사항들을 가지고 있는거

    public AIState positiveResult; //모든 디시전이 true라면 갈곳

    public AIState negativeResult;
}

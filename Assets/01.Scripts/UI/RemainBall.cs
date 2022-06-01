using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RemainBall : MonoBehaviour
{
    List<Image> slotList;

    private void Awake()
    {
        slotList = new List<Image>();
        transform.GetComponentsInChildren<Image>(slotList);
    }

    public void SetSlotCount(int cnt)
    {
        int realCnt = Mathf.Min(cnt, slotList.Count);
        for(int i = 0; i < realCnt; i++)
        {
            slotList[i].color = new Color(1, 1, 1, i);
        }

        for(int i = realCnt; i < slotList.Count; i++)
        {
            slotList[i].color = new Color(1, 1, 1, 0);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            SetSlotCount(3);
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            SetSlotCount(2);
        }
    }
}

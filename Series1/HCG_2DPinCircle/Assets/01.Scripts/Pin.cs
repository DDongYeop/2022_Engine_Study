using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
    [SerializeField] private GameObject _square;

    public void SetInPinStuckToTarget()
    {
        _square.SetActive(true);
    }
}

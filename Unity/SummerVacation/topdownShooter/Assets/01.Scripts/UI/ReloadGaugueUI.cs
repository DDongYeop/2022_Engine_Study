using UnityEngine;

public class ReloadGaugueUI : MonoBehaviour
{
    [SerializeField] private Transform _reloadBar;

    public void ReloadGaugueNormal(float value)
    {
        _reloadBar.localScale = new Vector3(value, 1, 1);
    }
}

//���극�� ���̴� << ��¼�� ����� ��Ʃ��� ������ 

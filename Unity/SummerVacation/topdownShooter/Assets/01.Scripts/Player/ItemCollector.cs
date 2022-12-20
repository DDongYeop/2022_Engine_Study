using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    private int _resoucrceLayer;
    private Player _player;

    private void Awake()
    {
        _resoucrceLayer = LayerMask.NameToLayer("Resource");
        _player = GetComponent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == _resoucrceLayer)
        {
            Resource resource = collision.gameObject.GetComponent<Resource>();

            if (resource != null)
            {
                switch (resource.ResourceData.resourcetype)
                {
                    case ResourceType.Ammo:
                        //이건 알아서 만들어라
                        resource.PickUpResource();
                        break;
                    case ResourceType.Health:
                        int value = resource.ResourceData.GetAmount();
                        _player.Health += value;
                        //팝업 텍스트 띄워줄꺼야
                        PopupText(value, resource);
                        resource.PickUpResource();
                        break;
                }
            }
        }
    }

    private void PopupText(int value, Resource res)
    {
        PopupText text = PoolManager.Instance.Pop("PopUpText") as PopupText;
        text?.Setup(value, res.transform.position + new Vector3(0, 0.5f, 0), false, res.ResourceData.popupTextColor);
    }
}

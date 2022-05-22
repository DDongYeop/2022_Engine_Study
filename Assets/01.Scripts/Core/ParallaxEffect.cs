using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    [SerializeField] private Vector2 _parallaxRatio;
    private Transform _mainCamTrm;
    private Vector3 _lastCamPos;
    private float _textureUnitSizeX;
    private float _textureUnitSizeY;

    private void Start()
    {
        _mainCamTrm = Camera.main.transform;
        _lastCamPos = _mainCamTrm.position; // 마지막 카메라 위치 기억

        SpriteRenderer sr = GetComponentInChildren<SpriteRenderer>();
        Sprite sprite = sr.sprite;
        Texture2D texture = sprite.texture;

        _textureUnitSizeX = texture.width / sprite.pixelsPerUnit;
        _textureUnitSizeY = texture.height / sprite.pixelsPerUnit;
        //텍스쳐의 너비가 몇인지 유닛인지 계산하기 위해서 (유니티 단위로 계산
    }

    private void LateUpdate()
    {
        Vector3 deltaMove = _mainCamTrm.position - _lastCamPos;

        transform.position += new Vector3(deltaMove.x * _parallaxRatio.x, deltaMove.y * _parallaxRatio.y);

        _lastCamPos = _mainCamTrm.position; //마지막 포지션 갱신

        if(Mathf.Abs(_mainCamTrm.position.x - transform.position.x) >= _textureUnitSizeX )
        {
            float offsetPositionX = (_mainCamTrm.position.x - transform.position.x) % _textureUnitSizeX;
            transform.position = new Vector3(_mainCamTrm.position.x + offsetPositionX, transform.position.y);
        }

        if (Mathf.Abs(_mainCamTrm.position.y - transform.position.y) >= _textureUnitSizeY)
        {
            float offsetPositionY = (_mainCamTrm.position.y - transform.position.y) % _textureUnitSizeY;
            transform.position = new Vector3(transform.position.x, _mainCamTrm.position.y + offsetPositionY);
        }
    }
}

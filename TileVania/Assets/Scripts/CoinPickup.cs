using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    [SerializeField] AudioClip _audioClip;
    [SerializeField] int point = 100;

    private bool _isPickUP = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !_isPickUP)
        {
            _isPickUP = true;

            FindObjectOfType<GameSession>().CoinAcheive(point);
            AudioSource.PlayClipAtPoint(_audioClip, Camera.main.transform.position);
            Destroy(gameObject);
        }
    }
}

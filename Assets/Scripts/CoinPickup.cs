using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    [SerializeField] AudioClip _audioClip;
    [SerializeField] int point = 100;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            FindObjectOfType<GameSession>().CoinAcheive(point);
            AudioSource.PlayClipAtPoint(_audioClip, Camera.main.transform.position);
            Destroy(gameObject);
        }
    }
}

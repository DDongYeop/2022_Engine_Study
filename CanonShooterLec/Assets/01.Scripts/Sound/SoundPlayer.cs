using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundPlayer : MonoBehaviour
{
    [SerializeField] private float _pitchRandomness = 0.2f;
    private AudioSource _addioSoruce = null;

    private void Awake()
    {
        _addioSoruce = GetComponent<AudioSource>();
    }

    protected void PlayClipWithPitch(AudioClip clip)
    {
        _addioSoruce.Stop();
        _addioSoruce.clip = clip;
        _addioSoruce.pitch = 1f + Random.Range(-_pitchRandomness, +_pitchRandomness);
        _addioSoruce.Play();
    }

    protected void PlayClip(AudioClip clip)
    {
        _addioSoruce.Stop();
        _addioSoruce.clip = clip;
        _addioSoruce.Play();
    }
}

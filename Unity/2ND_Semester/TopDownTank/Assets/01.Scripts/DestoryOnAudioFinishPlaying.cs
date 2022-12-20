using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryOnAudioFinishPlaying : MonoBehaviour
{
    private AudioSource _source;

    private void Awake() 
    {
        _source = GetComponent<AudioSource>();
    } 

    private void Start() 
    {
        Destroy(gameObject, _source.clip.length);
    }
}

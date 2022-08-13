using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAudio : MonoBehaviour
{
    private AudioClip _shootBulletClip = null;
    private AudioClip _outOfBulletClip = null;
    private AudioClip _reloadClip = null;

    public void SetAudioClip(AudioClip shoot, AudioClip outof, AudioClip reload)
    {
        _shootBulletClip = shoot;
        _outOfBulletClip = outof;
        _reloadClip = reload;
    }
}

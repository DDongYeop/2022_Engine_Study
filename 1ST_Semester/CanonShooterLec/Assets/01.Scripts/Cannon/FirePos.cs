using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePos : MonoBehaviour
{
    [SerializeField] private ParticleSystem _fireParticle;

    public void PlayParticle()
    {
        _fireParticle.Play();
    }
}

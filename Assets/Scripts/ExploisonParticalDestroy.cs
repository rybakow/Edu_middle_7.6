using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExploisonParticalDestroy : MonoBehaviour
{

    private ParticleSystem _particle;

    private void Start()
    {
        _particle = this.GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if (_particle.isPlaying == false)
            Destroy(this.gameObject);
    }
}

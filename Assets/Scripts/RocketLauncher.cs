using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class RocketLauncher : MonoBehaviour
{
    [SerializeField] private Transform _rocket;
    [SerializeField] private Transform _target;

    private Vector3 _pointForBomb;

    private void Start()
    {
        
    }

    private void Update()
    {
        _rocket.RotateAround(_target.position, Vector3.forward, 20 * Time.deltaTime * 2f);
    }
}


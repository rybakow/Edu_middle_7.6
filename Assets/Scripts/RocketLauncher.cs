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

    private GameObject _target2;

    private Vector3 _pointForBomb;

    private void Start()
    {
        _target2 = new GameObject();
        _target2.transform.position = new Vector3(_target.position.x / 2, _target.position.y, _target.position.z);
    }

    private void Update()
    {
        _rocket.RotateAround(_target2.transform.position, Vector3.forward, 20 * Time.deltaTime * 2f);
    }
}


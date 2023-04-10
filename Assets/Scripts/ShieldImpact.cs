using System;
using UnityEngine;

public class ShieldImpact : MonoBehaviour
{
    [SerializeField] private Material _materialAfter;

    private bool _destroyActivated;
    private float _currentTime;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Rocket"))
        {
            this.GetComponent<MeshRenderer>().material = _materialAfter;

            _destroyActivated = true;
        }
    }

    private void FixedUpdate()
    {
        if (_destroyActivated)
        {
            _currentTime += Time.deltaTime;

            if (_currentTime >= 0.5f)
                Destroy(this.gameObject);
        }
    }
}

using System;
using UnityEngine;

public class RocketController : MonoBehaviour
{
    private float _currentTime;

    [SerializeField] private ParticleSystem _startFire;
    [SerializeField] private ParticleSystem _startFog;
    
    [SerializeField] private ParticleSystem _destroyPartical;


    void Update()
    {
        _currentTime += Time.deltaTime;

        if (_currentTime > 2f)
        {
            _startFire.Stop();
            _startFog.Stop();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Damageable") && _currentTime > 0.5f)
        {
            Instantiate(_destroyPartical, this.transform.position, Quaternion.identity);
            DestroyRocket();
        }
    }
    
    private void DestroyRocket()
    {
        Destroy(this.gameObject);
    }
}

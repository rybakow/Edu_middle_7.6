using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour
{

    private float _currentTime;

    [SerializeField] private ParticleSystem _startFire;
    [SerializeField] private ParticleSystem _startFog;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _currentTime += Time.deltaTime;

        if (_currentTime > 2f)
        {
            _startFire.Stop();
            _startFog.Stop();
        }
        
        if (_currentTime > 10f)
            FinishExploison();

    }

    private void FinishExploison()
    {
        Destroy(this.gameObject);
    }
}

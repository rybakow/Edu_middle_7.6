using System.Collections.Generic;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class RocketLauncher : MonoBehaviour
{
    private Transform _launchPoint;
    [SerializeField] private List<Transform> _launchPoints;

    [SerializeField] private Transform _target;

    [SerializeField] private GameObject _rocket;

    private List<GameObject> _rocketArr;

    public float angleInDegrees;

    private float g = Physics.gravity.y;

    private float rotationSpeed = 2f;

    private void Start()
    {
        _rocketArr = new List<GameObject>();
        ChangeActualLaunchPoint();
    }

    private void Update()
    {
        launchRotation();

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void FixedUpdate()
    {
        RocketRotation();
    }

    private void launchRotation()
    {
        Vector3 fromTo = _target.position - transform.position;
        Vector3 fromToXZ = new Vector3(fromTo.x, 0f, fromTo.z);

        _launchPoint.localEulerAngles = new Vector3(angleInDegrees, 0f, 0f);
        transform.rotation = Quaternion.LookRotation(fromToXZ, Vector3.up);
        
    }

    private void Shoot()
    {
        Vector3 fromTo = _target.position - transform.position;
        Vector3 fromToXZ = new Vector3(fromTo.x, 0f, fromTo.z);
        
        float x = fromToXZ.magnitude;
        float y = fromToXZ.y;

        float anglesInRadians = angleInDegrees * Mathf.PI / 180;

        float v2 = (g * x * x) / (2 * (y - Mathf.Tan(anglesInRadians) * x) * Mathf.Pow(Mathf.Cos(anglesInRadians), 2));
        float v = Mathf.Sqrt(Mathf.Abs(v2));

        GameObject newRocket = Instantiate(_rocket, _launchPoint.position, _launchPoint.rotation);
        newRocket.GetComponent<Rigidbody>().velocity = _launchPoint.up * v;
        _rocketArr.Add(newRocket);

        ChangeActualLaunchPoint();
    }

    private void RocketRotation()
    {
        if (_rocketArr == null) return;

        for (int i = 0; i < _rocketArr.Count; i++)
        {
            if (_rocketArr[i] == null)
            {
                _rocketArr.Remove(_rocketArr[i]);
                return;
            }
            
            var distanceLaunchTarget = _target.position - transform.position;
            var distanceRocketTargetLeft = _target.position - _rocketArr[i].transform.position;

            _rocketArr[i].transform.LookAt(_target);

            if (distanceRocketTargetLeft.magnitude <= distanceLaunchTarget.magnitude * 0.85f)
            {
                _rocketArr[i].transform.localEulerAngles = new Vector3(0f, 0f, 150);
            }
        }
    }

    private void ChangeActualLaunchPoint()
    {
        var random = Random.Range(0, _launchPoints.Count);
        _launchPoint = _launchPoints[random];
    }
    
    
}


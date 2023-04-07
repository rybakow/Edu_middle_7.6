using System;
using Unity.VisualScripting;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class RocketLauncher3 : MonoBehaviour
{
    [SerializeField] private Transform _launchPoint;
    [SerializeField] private Transform _target;

    [SerializeField] private GameObject _rocket;
    
    public float angleInDegrees;

    private float g = Physics.gravity.y;

    private void Update()
    {
        launchRotation();

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    public void launchRotation()
    {
        Vector3 fromTo = _target.position - transform.position;
        Vector3 fromToXZ = new Vector3(fromTo.x, 0f, fromTo.z);

        _launchPoint.localEulerAngles = new Vector3(angleInDegrees, 0f, 0f);
        transform.rotation = Quaternion.LookRotation(fromToXZ, Vector3.up);
    }

    public void Shoot()
    {
        Vector3 fromTo = _target.position - transform.position;
        Vector3 fromToXZ = new Vector3(fromTo.x, 0f, fromTo.z);

        transform.rotation = Quaternion.LookRotation(fromToXZ, Vector3.up);
        
        float x = fromToXZ.magnitude;
        float y = fromToXZ.y;

        float anglesInRadians = angleInDegrees * Mathf.PI / 180;

        float v2 = (g * x * x) / (2 * (y - Mathf.Tan(anglesInRadians) * x) * Mathf.Pow(Mathf.Cos(anglesInRadians), 2));
        float v = Mathf.Sqrt(Mathf.Abs(v2));

        GameObject newRocket = Instantiate(_rocket, _launchPoint.position, _launchPoint.rotation);
        newRocket.GetComponent<Rigidbody>().velocity = _launchPoint.up * v;

    }
}

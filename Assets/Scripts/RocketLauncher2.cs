using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class RocketLauncher2 : MonoBehaviour
{
    public float angle = 0;

    public float speed = 1;
    public float radius = 0.5f;
    public bool isCircle = false;

    // запоминать свое нахождение и делать его центром окружности
    public Vector3 cachedCenter;

    void Update() {
        if (isCircle) {
            angle += Time.deltaTime;
            var x = Mathf.Cos(angle * speed) * radius;
            var y = Mathf.Sin(angle * speed) * radius;
            transform.position = new Vector3(x, y) + cachedCenter - new Vector3(radius, 0);
        } else {
            angle = 0;
            cachedCenter = transform.position;
            var x = transform.position.x;
            var y = transform.position.y;
            x += 0.5f * Time.deltaTime;

            transform.position = new Vector3(x, y);
        }
    }
}

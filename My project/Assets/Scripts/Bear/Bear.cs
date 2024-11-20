using System;
using UnityEngine;

public class Bear : MonoBehaviour
{
    public string name = "test";

    public GameObject planetCenter;
    private float angle;
    public float speed = 1.0f;

    const float radius = 4.5f; // сопоставить с радиусом планеты

    public float initialAngle;

    void Start()
    {
        System.Random rand = new System.Random();
        angle = rand.Next(0, 360);
    }

    public void Move()
    {
        angle += speed * Time.deltaTime;

        float x = planetCenter.transform.position.x + Mathf.Cos(angle) * radius;
        float y = planetCenter.transform.position.y + Mathf.Sin(angle) * radius;

        transform.position = new Vector3(x, y, transform.position.z);

        Vector3 direction = planetCenter.transform.position - transform.position;
        float rotationZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotationZ);
    }

    void Update()
    {
        Move();
    }
}
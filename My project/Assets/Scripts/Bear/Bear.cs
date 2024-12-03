// using System;
// using UnityEngine;

// public class Bear : MonoBehaviour
// {
//     public string name = "test";

//     public BuildingSystem buildingSystem;
//     public GameObject planetCenter;
//     private float angle;
//     public float speed = 1.0f;

//     public GameObject infoPanel;

//     const float radius = 6.0f; // сопоставить с радиусом планеты

//     public float initialAngle;

//     void Start()
//     {
//         buildingSystem = GetComponent<BuildingSystem>();
//         System.Random rand = new System.Random();
//         angle = rand.Next(0, 360);
//     }

//     public void Move()
//     {
//         angle += speed * Time.deltaTime;

//         float x = planetCenter.transform.position.x + Mathf.Cos(angle) * radius;
//         float y = planetCenter.transform.position.y + Mathf.Sin(angle) * radius;

//         transform.position = new Vector3(x, y, transform.position.z);

//         Vector3 direction = planetCenter.transform.position - transform.position;
//         float rotationZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
//         transform.rotation = Quaternion.Euler(0, 0, rotationZ);
//     }

//     public void OnClick() // не работает пока
//     {
//         // for (int i = 0; i < buildingSystem.buildings.Capacity; i++)
//         // {
//         //     Debug.Log(buildingSystem.buildings[i].instance.transform.position);
//         // }
//         Debug.Log("Hello");
//     }


//     void Update()
//     {
//         Move();
//     }
// }
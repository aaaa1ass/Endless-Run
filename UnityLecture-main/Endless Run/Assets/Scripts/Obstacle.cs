using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    void Update()
    {
        transform.Translate(Vector3.back * GameManager.instance.speed * Time.deltaTime);   
    }
}

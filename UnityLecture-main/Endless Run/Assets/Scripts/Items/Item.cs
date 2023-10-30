using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    protected GameObject rotatePrefab; 
    [SerializeField] float rotateSpeed = 200.0f;
    [SerializeField] protected ParticleSystem effect;

    protected void Awake()
    {
        rotatePrefab = GameObject.Find("Rotation Prefab");    
    }

    protected void OnEnable()
    {
        transform.rotation = Quaternion.Euler
        (
               rotatePrefab.transform.rotation.eulerAngles.x,
               rotatePrefab.transform.rotation.eulerAngles.y,
               rotatePrefab.transform.rotation.eulerAngles.z
        ); ;
    }

    void Update()
    {
        transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);   
    }
}

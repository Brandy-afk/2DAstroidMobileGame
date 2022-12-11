using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astroid : MonoBehaviour
{
    
[SerializeField] float rotationSpeed = 1f;
health health;

 void Start() 
{
    
health = FindObjectOfType<health>();

}


 void Update() 
{
    Rotate();
    
}


private void OnTriggerEnter(Collider other) 
{

if(other.gameObject.GetComponent<health>())
{
    health.Crash();
    Destroy(gameObject);
}

}


void Rotate()
{

transform.Rotate(0, 0, rotationSpeed);

}

private void OnBecameInvisible() 
{

Destroy(gameObject);
    
}

}

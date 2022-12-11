using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float forceMagnitude;
    [SerializeField] private float maxVelocity;
    [SerializeField] private float rotationSpeed;



    private Camera mainCam;
    private Rigidbody rgbd;

    
    private Vector3 movementDirection;
  
    void Start()
    {
        
    mainCam = Camera.main;
    rgbd = GetComponent<Rigidbody>();


    }

 
    void Update()
    {
    
     ProcessInput();
     KeepPlayerOnScreen();
     RotateToFaceVelocity();
       
    }

   void FixedUpdate() 
    {

        if(movementDirection == Vector3.zero) {return;}

        rgbd.AddForce(movementDirection * forceMagnitude, ForceMode.Force);

        rgbd.velocity = Vector3.ClampMagnitude(rgbd.velocity, maxVelocity);



    }

private void ProcessInput()
{

  if(Touchscreen.current.primaryTouch.press.isPressed)
       {
         Vector2 touchPosition = Touchscreen.current.primaryTouch.position.ReadValue();

         Vector3 worldPosition = mainCam.ScreenToWorldPoint(touchPosition);

        movementDirection = transform.position - worldPosition; 
        movementDirection.z = 0f;
        movementDirection.Normalize();

       }
       else
       {
        movementDirection = Vector3.zero;
       }

}

private void KeepPlayerOnScreen()
{
Vector3 newPosition = transform.position;

Vector3 viewportPosition = mainCam.WorldToViewportPoint(transform.position);

if(viewportPosition.x > 1.05)
{

    newPosition.x = -newPosition.x;

}

if(viewportPosition.x < -.05)
{

    newPosition.x = -newPosition.x;

}

if(viewportPosition.y > 1.05)
{

    newPosition.y = -newPosition.y;

}

if(viewportPosition.y < -.05)
{

    newPosition.y = -newPosition.y;

}


transform.position = newPosition;

}



void RotateToFaceVelocity()
{

  if(rgbd.velocity == Vector3.zero) {return;}

    Quaternion targetRotation = Quaternion.LookRotation(rgbd.velocity, Vector3.back);
    transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

}



}

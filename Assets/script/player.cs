using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
   [SerializeField] private Transform groundCheckTransform= null;
   [SerializeField] private LayerMask playerMask;
    private bool jumpKeyWasPressed;
    private float horizontalInput;
    private Rigidbody rigidbodyComponent;
    

    void Start()
    {
        rigidbodyComponent = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpKeyWasPressed = true;
        }
        horizontalInput = Input.GetAxis("Horizontal");
    }
    private void FixedUpdate()
    {
                rigidbodyComponent.velocity = new Vector3(horizontalInput, rigidbodyComponent.velocity.y, 0);
      if(Physics.OverlapSphere(groundCheckTransform.position,0.1f,playerMask).Length==0 )
      {

      }
 
        if (jumpKeyWasPressed)
        {
            rigidbodyComponent.AddForce(Vector3.up * 7 , ForceMode.VelocityChange);
            jumpKeyWasPressed = false;
        } 
    }
    private void OnTriggerEnter(Collider Other)
    {
        if(Other.gameObject.layer ==9)
        {
            Destroy(Other.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipController : MonoBehaviour
{
    Rigidbody rb;
    private Vector3 lastPosition;
    private Vector3 direction = Vector3.zero;
    


    [Header("Movement")]
    [SerializeField] float _MovementSpeed;
    [SerializeField] float _MaxSpeed;
    [SerializeField] float currentSpeed;
    [SerializeField] bool canRotate;
    [SerializeField] float decelerationMultiplier;
    public float velocityMagnitude;

    [Header("Steering")]
    [SerializeField] float _turningSpeed;


    public void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float Vertical = Input.GetAxis("Vertical");
        float Horizontal = Input.GetAxis("Horizontal");

        direction = new Vector3(Horizontal, Vertical, 0).normalized;

        canRotate = false;
       
                if (Vertical > 0.1f || Vertical < -0.1f)
                {
                    canRotate = true;
                }
           
    }

    private void FixedUpdate()
    {


        //currentSpeed = (transform.position - lastPosition).magnitude / Time.deltaTime;

        ////Save the position for the next update
        //lastPosition = transform.position;

        //check if the turning is able or not
        if (canRotate == true)
         { rb.AddTorque(0, direction.x *_turningSpeed, 0); }

        //add movement force
        rb.AddForce( transform.forward * direction.y * _MovementSpeed);
        velocityMagnitude = rb.velocity.magnitude;

        //create limitation for the _MovementSpeed 
        if (velocityMagnitude >= _MaxSpeed)
        {
            rb.AddForce(-rb.velocity * decelerationMultiplier, ForceMode.Acceleration);
        }
        else
        {
            rb.velocity = transform.forward * velocityMagnitude;
        }
    }

}






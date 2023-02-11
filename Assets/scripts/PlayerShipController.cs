using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipController : MonoBehaviour
{

   // [SerializeField] 

    [SerializeField] float _moveMentSpeed;
    [SerializeField] float _turningSpeed;
    [SerializeField] float _decelerate; 
    [SerializeField] float _WaitTimeToStop; 

    [SerializeField]bool canRotate;
    [SerializeField]bool isThereMotion; 

    Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        isThereMotion = true;
    }

    private void Update()
    {

        canRotate = false;
        float _Horizontal = Input.GetAxis("Horizontal");
        float _Vertical = Input.GetAxis("Vertical");

        if (Input.GetAxis("Vertical") > 0.2f)
        {
            rb.AddRelativeForce(Vector3.forward * _moveMentSpeed * Time.fixedDeltaTime * Input.GetAxis("Vertical"));
            canRotate = true;
            if (canRotate == true)
                if (Input.GetAxis("Horizontal") < -0.2f || Input.GetAxis("Horizontal") > 0.2f)
                {
                    transform.rotation = Quaternion.EulerRotation(0, transform.rotation.ToEulerAngles().y + Input.GetAxis("Horizontal") * _turningSpeed * Time.fixedDeltaTime, 0);
                    

                        rb.AddTorque(0f, _Horizontal * _turningSpeed * Time.deltaTime, 0f);
                        //rb.AddForce(transform.right * h * _turningSpeed * Time.deltaTime);

                }
            rb.AddForce(transform.forward * _Vertical * _moveMentSpeed * Time.deltaTime);
            isThereMotion = false;
        }
        else
        {
            rb.velocity = rb.velocity * _decelerate * Time.deltaTime;
            StartCoroutine(Stopping());
            //rb.AddForce((-transform.forward * v) /(_decelerate * Time.deltaTime));
        }

        Debug.Log("h = "+ _Horizontal + "v = "+ _Vertical);

    }


    IEnumerator Stopping()
    {
        yield return new WaitForSeconds(_WaitTimeToStop);
        isThereMotion = true;
    }

    
}

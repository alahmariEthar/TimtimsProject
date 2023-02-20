using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mines : MonoBehaviour
{
    [Header("Mine effect Contorller")]
    [SerializeField] GameObject _Mines;
    [SerializeField] float _UpForce;
    [SerializeField] float _Radius;
    [SerializeField] float _Force;

    [Header("Mine Color Contorller")]
    [SerializeField] Color black = Color.black;
    [SerializeField] Color red = Color.red;
    [Range (0,7)]
    [SerializeField] float _FlashingSpeed;
    Renderer rend;

    bool isItexplode;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Mines"))
        {
            isItexplode = true;
            _FlashingSpeed = 4;
            Invoke("Explode" , 5);
        }
    }

    private void Start()
    {
        rend = GetComponent<Renderer>();
        isItexplode = false;
    }

    private void Update()
    {
      
        float t = (Mathf.PingPong(Time.time * _FlashingSpeed, 1));
            GetComponent<Renderer>().material.color = Color.Lerp(black, red, t);
       
    }

   void Explode()
    {
        if (isItexplode == true)
        {

            Vector3 explodePosition = _Mines.transform.position;
            Collider[] colliders = Physics.OverlapSphere(explodePosition, _Radius);
            foreach (Collider hit in colliders)
            {
                Rigidbody rb = hit.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.AddExplosionForce(_Force, explodePosition, _Radius, _UpForce ,ForceMode.Impulse);
                }
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashingColor : MonoBehaviour
{
    [Header("Mine Color Contorller")]
    [SerializeField] Color black = Color.black;
    [SerializeField] Color red = Color.red;
    //[Range(0, 10)]
    [SerializeField] float _FlashingSpeed;
    //Renderer rend;
    float starttime;
    public bool repetable;

    private void Start()
    {
        starttime = Time.time;
        
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Mines"))
        {
            repetable = true;
            _FlashingSpeed = 6;
        }
    }
    public void Update()
    {
        if (!repetable)
        {
            float t = (Time.time - starttime) * _FlashingSpeed;
            GetComponent<Renderer>().material.color = Color.Lerp(black, red, t);
        }
        else
        {
            
             float t = (Mathf.Sin(Time.time - starttime) * _FlashingSpeed);
             GetComponent<Renderer>().material.color = Color.Lerp(black, red, t);
            
        }
        
    }
}

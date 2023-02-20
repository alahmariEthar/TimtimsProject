using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingObjects : MonoBehaviour
{
    [SerializeField] Transform[] FloatingPoints;

    [SerializeField] float _UnderWaterDrag;
    [SerializeField] float _UnderWaterAngularDrag;
    [SerializeField] float _AirDrag;
    [SerializeField] float _AirAngularDrag;
    [SerializeField] float _FloatingPower;

    [SerializeField] float _WaterHight;


    [SerializeField]Rigidbody rb;
    int _FloatingPointsUnderWater;

    bool isUnderWater;

 
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    void FixedUpdate()
    {
        _FloatingPointsUnderWater = 0;

        for(int i = 0; i < FloatingPoints.Length; i++)
        {
         float difference = FloatingPoints[i].position.y - _WaterHight;

                if (difference < 0)
                {
                    rb.AddForceAtPosition(Vector3.up * _FloatingPower * Mathf.Abs(difference), FloatingPoints[i].position, ForceMode.Force);
                _FloatingPointsUnderWater += 1;
                    if (!isUnderWater)
                    {
                        isUnderWater = true;
                        Switchstate(true);
                    }
                }
        }
        if (isUnderWater && _FloatingPointsUnderWater ==0)
        {
            isUnderWater = false;
            Switchstate(false);
        }
    }

    void Switchstate(bool UnderWater)
    {
        if (!UnderWater)
        {
            rb.drag = _UnderWaterDrag;
            rb.angularDrag = _UnderWaterAngularDrag;
        }
        else
        {
            rb.drag = _AirDrag;
            rb.angularDrag = _AirAngularDrag;
        }
    }
}

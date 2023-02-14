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


    [SerializeField]Rigidbody rigidbody;
    int _FloatingPointsUnderWater;

    bool isUnderWater;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _FloatingPointsUnderWater = 0;

        for(int i = 0; i < FloatingPoints.Length; i++)
        {
         float difference = FloatingPoints[i].position.y - _WaterHight;

                if (difference < 0)
                {
                    rigidbody.AddForceAtPosition(Vector3.up * _FloatingPower * Mathf.Abs(difference), FloatingPoints[i].position, ForceMode.Force);
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
            rigidbody.drag = _UnderWaterDrag;
            rigidbody.angularDrag = _UnderWaterAngularDrag;
        }
        else
        {
            rigidbody.drag = _AirDrag;
            rigidbody.angularDrag = _AirAngularDrag;
        }
    }
}

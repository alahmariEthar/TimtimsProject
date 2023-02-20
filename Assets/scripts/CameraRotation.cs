using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    [Header("Rotation")]
    [SerializeField] float _MouseSensitivity;
    [SerializeField] float _SmoothRotation;
    public float _RotationY_Limitation;
    float _RotationY;
    float _RotationX;
    Vector3 _currentRotation;
    Vector3 _smoothVelocity = Vector3.zero;

    [Header("Target")]
    public Transform _Target;
    public float _DistanceFromTarget;

    void LateUpdate()
    {
        float _MouseX = Input.GetAxis("Mouse X") * _MouseSensitivity;
        float _MouseY = Input.GetAxis("Mouse Y") * _MouseSensitivity;

        _RotationY += _MouseX;
        _RotationX += _MouseY;

        _RotationX = Mathf.Clamp(_RotationX, _RotationY_Limitation, 40);

        Vector3 _NextRotation = new Vector3(_RotationX, _RotationY);
        _currentRotation = Vector3.SmoothDamp(_currentRotation, _NextRotation, ref _smoothVelocity, _SmoothRotation);
        transform.localEulerAngles = _currentRotation;
        transform.position = _Target.position - transform.forward * _DistanceFromTarget;

    }


}

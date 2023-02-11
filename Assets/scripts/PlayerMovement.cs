using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] CharacterController controller;
    [SerializeField] float _Speed;
    [SerializeField] float _TurnSmooth;
    [SerializeField] float _TurnSmoothVelocity;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float _Horizontal = Input.GetAxis("Horizontal");
        float _Vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(-_Horizontal, 0f, -_Vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float _TargetAngel = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float _Angel = Mathf.SmoothDampAngle(transform.eulerAngles.y, _TargetAngel, ref _TurnSmoothVelocity, _TurnSmooth);
            transform.rotation = Quaternion.Euler(0f, _Angel, 0f);
            controller.Move(direction * _Speed);
        }
    }
}

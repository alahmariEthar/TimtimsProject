using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] CharacterController controller;
    private Vector3 playerVelocity;
    [SerializeField] bool groundedPlayer;
    [SerializeField] float playerSpeed = 6;
    [SerializeField] float jumpHeight = 1.0f;
    [SerializeField] float gravityValue = -9.81f;
    [SerializeField] float _TurnSmooth;
    [SerializeField] float _TurnSmoothVelocity;

    private void Start()
    {
        
    }

    void Update()
    {
        float _Horizontal = Input.GetAxis("Horizontal");
        float _Vertical = Input.GetAxis("Vertical");

        Vector3 move = transform.forward * _Vertical + transform.right * _Horizontal;
        controller.Move(playerSpeed*Time.deltaTime*move);

        Vector3 direction = new Vector3(-_Horizontal, 0f, -_Vertical).normalized;

        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }


        if (direction != Vector3.zero)
        {
            transform.forward = direction;
        }

        if (direction.magnitude >= 0.1f)
        {
            float _TargetAngel = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float _Angel = Mathf.SmoothDampAngle(transform.eulerAngles.y, _TargetAngel, ref _TurnSmoothVelocity, _TurnSmooth);
            transform.rotation = Quaternion.Euler(0f, _Angel, 0f);
            controller.Move(direction * playerSpeed);
        }


        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}

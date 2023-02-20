using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] CharactersManager fall;

    [Header("PlayerMovement")]
    [SerializeField] private float speed;
    [Header("PlayerTurning")]
    [SerializeField] float _TurnSmooth;
    [SerializeField] float _TurnSmoothVelocity;
    [Header("PlayerJump")]
    [SerializeField] private float jumpForce;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;


    private Rigidbody rb;

    private bool canJump;


   
    
    
    private void Start()
    {
        
        rb = GetComponent<Rigidbody>();
    }

    
    private void Update()
    {

        float Horizontal = Input.GetAxis("Horizontal") * speed;
        float Vertical = Input.GetAxis("Vertical") * speed;

        
        Vector3 movement = new Vector3(-Horizontal, 0, -Vertical);
        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);


        if (movement.magnitude >= 0.1f)
        {
            float _TargetAngel = Mathf.Atan2(movement.x, movement.z) * Mathf.Rad2Deg;
            float _Angel = Mathf.SmoothDampAngle(transform.eulerAngles.y, _TargetAngel, ref _TurnSmoothVelocity, _TurnSmooth);
            transform.rotation = Quaternion.Euler(0f, _Angel, 0f);
           
        }





        bool grounded = Physics.Linecast(transform.position, groundCheck.position, groundLayer);

        // Visually draws a red line in place of the Linecast
        Debug.DrawLine(transform.position, groundCheck.position, Color.red);

        // Determines when the player is allowed to jump based on whether the Linecast detects the groundLayer or not
        if (grounded == true)
            canJump = true;
        else
            canJump = false;

        Jump();
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && canJump == true)
        {
            canJump = false;
            rb.AddForce(Vector3.up * jumpForce);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("DangerZone"))
        {
            fall.Respawn();
        }
    }
}

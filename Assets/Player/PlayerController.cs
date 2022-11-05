using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]

public class PlayerController : MonoBehaviour
{
    private Rigidbody PlayerBody;
    private float distToGround;
    private Collider m_Collider;
    [SerializeField] private Joystick joystick;
    [SerializeField] private float Speed;
    [SerializeField] private float Jumpforce;
    [SerializeField] private bool isJumping;

    // Start is called before the first frame update
    void Start()
    {
        m_Collider = GetComponent<Collider>();
        distToGround = m_Collider.bounds.extents.y;
        PlayerBody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    bool IsGrounded() {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
    }

    public void setIsJumping(bool value){
        isJumping = value;
    }

    void MovePlayer()
    {
        float horizontal = (Application.platform == RuntimePlatform.Android) ? joystick.Horizontal : Input.GetAxis("Horizontal");
        float vertical = (Application.platform == RuntimePlatform.Android) ? joystick.Vertical : Input.GetAxis("Vertical");
        Vector3 playerMovementInput = new Vector3(horizontal, 0f, vertical);

        if (playerMovementInput != Vector3.zero)
        {

            Matrix4x4 matrix = Matrix4x4.Rotate(Quaternion.Euler(0, 45, 0));

            Vector3 skewedInput = matrix.MultiplyPoint3x4(playerMovementInput);

            Vector3 relative = (transform.position + skewedInput) - transform.position;
            Quaternion rot = Quaternion.LookRotation(relative, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, 360);
        }

        PlayerBody.MovePosition(transform.position + (transform.forward * playerMovementInput.magnitude) * Speed * Time.deltaTime);
        
        if(Input.GetKeyDown(KeyCode.Space)){
            setIsJumping(true);
        }

        if (isJumping && IsGrounded())
        {
            setIsJumping(false);
            PlayerBody.AddForce(Vector3.up * Jumpforce, ForceMode.Impulse);
        }

    }
}

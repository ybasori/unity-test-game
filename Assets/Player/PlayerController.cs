using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]

public class PlayerController : MonoBehaviour
{
    private Rigidbody PlayerBody;
    [SerializeField] private float Speed;
    [SerializeField] private float Jumpforce;

    // Start is called before the first frame update
    void Start()
    {
        PlayerBody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerBody.AddForce(Vector3.up * Jumpforce, ForceMode.Impulse);
        }

    }
}

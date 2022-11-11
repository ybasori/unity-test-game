using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]

public class PlayerController : MonoBehaviour
{
    private Rigidbody PlayerBody;
    private float distToGround;
    private Collider m_Collider;
    private Animator animator;
    [SerializeField] public Joystick joystick;
    [SerializeField] private float Speed;
    [SerializeField] private float Jumpforce;
    [SerializeField] private bool isJumping;
    [SerializeField] private bool useJoystick;

    [Header("Appearance Game Object")]
    [SerializeField] private GameObject maleGameObject;
    [SerializeField] private GameObject femaleGameObject;

    [Header("Appearance")]
    public string gender = "female";
    public float explore = 0f;
    private string genderPrev;

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {

        transform.localPosition = new Vector3(transform.localPosition.x, 4f, transform.localPosition.z);
    }

    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
    }

    public void SetIsJumping(bool value)
    {
        isJumping = value;
    }

    void MovePlayer()
    {
        float horizontal = 0f;
        float vertical = 0f;

        float mvhorizontal = 0f;
        float mvvertical = 0f;

        if (useJoystick)
        {
            horizontal = joystick.Horizontal;
            vertical = joystick.Vertical;

        }
        else
        {
            horizontal = (Application.platform == RuntimePlatform.Android) ? joystick.Horizontal : Input.GetAxis("Horizontal");
            vertical = (Application.platform == RuntimePlatform.Android) ? joystick.Vertical : Input.GetAxis("Vertical");
        }


        if (horizontal >= .2f)
        {
            mvhorizontal = 1f;
        }
        if (horizontal <= -.2f)
        {
            mvhorizontal = -1f;
        }
        if (vertical >= .2f)
        {
            mvvertical = 1f;
        }
        if (vertical <= -.2f)
        {
            mvvertical = -1f;
        }

        Vector3 playerMovementInput = new Vector3(horizontal, 0f, vertical);

        if (playerMovementInput != Vector3.zero)
        {

            Matrix4x4 matrix = Matrix4x4.Rotate(Quaternion.Euler(0, 45, 0));

            Vector3 skewedInput = matrix.MultiplyPoint3x4(playerMovementInput);

            Vector3 relative = (transform.position + skewedInput) - transform.position;
            Quaternion rot = Quaternion.LookRotation(relative, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, 360);
        }

        PlayerBody.MovePosition(transform.position + (transform.forward * playerMovementInput.magnitude) * (Speed * (!Debug.isDebugBuild ? 1 : 2)) * Time.deltaTime);
        explore = ((mvhorizontal != 0 ? mvhorizontal : mvvertical != 0 ? mvvertical : 0));
        animator.SetFloat("explore", explore);

        if (Input.GetKeyUp(KeyCode.Space))
        {
            SetIsJumping(true);
        }

        // Debug.Log(IsGrounded());
        if (isJumping && IsGrounded())
        {
            SetIsJumping(false);
            PlayerBody.AddForce(Vector3.up * Jumpforce, ForceMode.Impulse);
        }

    }

    void Appearance()
    {
        if (gender != genderPrev)
        {
            genderPrev = gender;
            if (gender == "female")
            {
                femaleGameObject.SetActive(true);
                maleGameObject.SetActive(false);

                animator.avatar = femaleGameObject.GetComponent<Animator>().avatar;
                femaleGameObject.transform.SetSiblingIndex(1);
            }
            if (gender == "male")
            {
                maleGameObject.SetActive(true);
                femaleGameObject.SetActive(false);
                animator.avatar = maleGameObject.GetComponent<Animator>().avatar;
                maleGameObject.transform.SetSiblingIndex(1);
            }
        }
        else
        {

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        m_Collider = GetComponent<Collider>();
        distToGround = m_Collider.bounds.extents.y;
        PlayerBody = gameObject.GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();


        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        Appearance();
        if (SceneManager.GetActiveScene().name == "AppearanceScene") { }
        else
        {
            MovePlayer();
        }
    }


}

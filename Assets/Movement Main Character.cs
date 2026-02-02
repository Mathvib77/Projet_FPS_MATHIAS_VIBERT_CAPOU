using System.Runtime.CompilerServices;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public float moveSpeed = 5f;   //Character's movement speed
    public float jumpForce = 5f;  // Force applied when jumping
    public Transform groundCheck;  // A point to check if the player is grounded
    public float groundCheckRadius = 0.2f; // Radius of the ground check
    public LayerMask groundLayer;  // Layer considered as ground

    public Rigidbody rb;
    public bool isGrounded = true;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the player is on the ground
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundLayer);

        transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * 10f, 0f, 0f);
        transform.Translate(0f, 0f, Input.GetAxis("Vertical") * Time.deltaTime * 10f);
        transform.Rotate(0f, Input.GetAxis("Mouse X") * Time.deltaTime * 700f, 0f);
        //transform.Rotate(-Input.GetAxis("Mouse Y") * Time.deltaTime * 200f, 0f, 0f);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Ground")
        {
            isGrounded = true;
        }
    }
}

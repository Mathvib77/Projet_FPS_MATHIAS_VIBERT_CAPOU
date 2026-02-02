using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float jumpForce = 6f;
    public float speed = 5f;
    public float Jump;
    public float jumpHeight = 2f;
    public bool isGrounded = false;
    public LayerMask TerrainLayers;

    private Collider PlayerCollider;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Terrain"))
        {
            isGrounded = true;
        }
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w"))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        if (Input.GetKey("s"))
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
        if (Input.GetKey("a"))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (Input.GetKey("d"))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        if (Input.GetAxis("Jump") != 0 && isGrounded) 
        {
            Jump = Input.GetAxis("Jump") * jumpForce;
            rb.AddForce(new Vector3(0, Jump, 0), ForceMode.Impulse);
            isGrounded = false;
        }
        
    }
}

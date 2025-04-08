using UnityEngine;

public class tPlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    //create separate variable for key mappings to make binding customisable
    //potentially make variable private; check need for protection
    public float x_velocity;
    public float speed = 3f;
    public bool looking_right = true; //make private later

    public KeyCode jump_key = KeyCode.Space;
    public float jump_height = 7.5f;
    public bool is_ground = true; //make private later


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        x_velocity = Input.GetAxisRaw("Horizontal");

        if (x_velocity < 0f && looking_right == true) {
            transform.eulerAngles = new Vector3(0f, -180f, 0f);
            looking_right = false;
        }
        else if (x_velocity > 0f && looking_right == false) {
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
            looking_right = true;
        }

        if (Input.GetKey(jump_key) && is_ground == true) {
                Jump();
                is_ground = false;
        }
    }

    void FixedUpdate()
    {
        //delta time keeps movement constant regardless of local framerate
        //consider moving speed scalar outside of vector constuctor; compare execution?
        transform.position += new Vector3(speed*x_velocity, 0f, 0f) * Time.fixedDeltaTime; 
    }

    void Jump() {
        Vector2 velocity = rb.linearVelocity;
        velocity.y = jump_height;
        rb.linearVelocity = velocity;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground") {
            is_ground = true;
        }
    }
}

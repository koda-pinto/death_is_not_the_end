using UnityEngine; 
using System.Collections;

public class tPlayerMovement : MonoBehaviour
{
    //importing components
    public Animator animator;
    public Rigidbody2D rb;
    //create separate variable for key mappings to make binding customisable
    //potentially make variable private; check need for protection
    public float x_velocity;
    public float speed = 7f;
    public bool looking_right = true; //make private later. hey why not now pointdexter?!
    public KeyCode jump_key = KeyCode.Space;
    public KeyCode dash_key = KeyCode.LeftShift;
    public float jump_height = 16f;
    public bool is_ground = true; //make private later

    public float dashSpeed = 10f;
    public float dashDuration = 0.2f;

    private bool dashUsed;
    private float originalGravityScale;

    void Start()
    {
        originalGravityScale = rb.gravityScale;
    }

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

        if (Input.GetKeyDown(dash_key) && (is_ground || !dashUsed)) {
            Dash();
        }

        if (Mathf.Abs(x_velocity) > 0f) 
            animator.SetBool("walk", true);
        else if (x_velocity == 0f)
            animator.SetBool("walk", false);
    }

    void FixedUpdate()
    {
        transform.position += new Vector3(speed * x_velocity, 0f, 0f) * Time.fixedDeltaTime; 
    }

    void Jump() {
        rb.gravityScale = originalGravityScale;
        Vector2 velocity = rb.linearVelocity;
        velocity.y = jump_height;
        rb.linearVelocity = velocity;
        animator.SetBool("jump", true);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground") {
            is_ground = true;
            animator.SetBool("jump", false);
            dashUsed = false;
        }
    }

    void Dash() {
        float dir = looking_right ? 1f : -1f;
        rb.gravityScale = 0f;
        rb.linearVelocity = new Vector2(dir * dashSpeed, 0f);
        if (!is_ground) dashUsed = true;
        StartCoroutine(EndDash());
    }

    IEnumerator EndDash() {
        yield return new WaitForSeconds(dashDuration);
        rb.gravityScale = originalGravityScale;
        rb.linearVelocity = new Vector2(0f, rb.linearVelocity.y);
    }
}

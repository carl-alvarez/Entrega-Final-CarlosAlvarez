using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerMovement : MonoBehaviour
{
    public float speed = 5;
    [SerializeField] Rigidbody rb;
    [SerializeField] float horizontalMultiplier = 2;
    float horizontalInput;

    public float speedIncreasePerPoint = 1f;

    
    [SerializeField] float jumpForce = 400f;
    [SerializeField] LayerMask groundMask;

    public bool alive = true;

    public Animator _anim;

    public bool saltoActivo;

    public int jumpCount;

    float altura;

    
    void Start()
    {
        Time.timeScale = 1.0f;
        _anim = gameObject.GetComponent<Animator>();
        _anim.Play("Desolve");

    }

    private void FixedUpdate()
    {
        if (!alive) return;

        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * speed * horizontalMultiplier * Time.fixedDeltaTime;

        rb.MovePosition(rb.position + forwardMove + horizontalMove);
    }



    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.GetChild(0).transform.Rotate(speed, 0, 0, Space.Self);
        if (Physics.Raycast(transform.position, Vector3.down, altura, groundMask) && !Input.GetKeyDown(KeyCode.Space))
        {
            JumpReset();
        }
        
        

        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 3)
        {
            Jump();
            jumpCount++;
        }

        if (transform.position.y < -5)
        {
            Die();
        }
    }

    public void Die()
    {
        alive = false;
        speed = 0;                
        
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Jump()
    {
        if (saltoActivo == true) 
        {
            float height = GetComponent<Collider>().bounds.size.y; //agarrar collider para ver si el player est� apoyado en suelo

            bool isGrounded = Physics.Raycast(transform.position, Vector3.down, (height / 2) + 0.1f, groundMask);

            //para saltar

            rb.AddForce(Vector3.up * jumpForce);

        }       
        
        
    }

    public void JumpReset()
    {
        jumpCount = 1;
    }


}
